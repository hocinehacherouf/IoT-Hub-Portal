// Copyright (c) CGI France. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace IoTHub.Portal.Client.Services
{
    public class PlanningClientService : IPlanningClientService
    {
        private readonly HttpClient http;
        private readonly string apiUrlBase = "api/planning";

        public PlanningClientService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<string> CreatePlanning(PlanningDto Planning)
        {
            var response = await this.http.PostAsJsonAsync(this.apiUrlBase, Planning);

            if (Planning.Id != null)
            {
                return Planning.Id;
            }

            //Retrieve Planning ID
            var responseJson = await response.Content.ReadAsStringAsync();
            var updatedPlanning = Newtonsoft.Json.JsonConvert.DeserializeObject<PlanningDto>(responseJson);

            return updatedPlanning.Id.ToString();
        }

        public Task UpdatePlanning(PlanningDto Planning)
        {
            return this.http.PutAsJsonAsync(this.apiUrlBase, Planning);
        }

        public Task DeletePlanning(string PlanningId)
        {
            return this.http.DeleteAsync($"{this.apiUrlBase}/{PlanningId}");
        }

        public Task<PlanningDto> GetPlanning(string PlanningId)
        {
            return this.http.GetFromJsonAsync<PlanningDto>($"{this.apiUrlBase}/{PlanningId}")!;
        }

        public async Task<List<PlanningDto>> GetPlannings()
        {
            return await this.http.GetFromJsonAsync<List<PlanningDto>>(this.apiUrlBase) ?? new List<PlanningDto>();
        }
    }
}
