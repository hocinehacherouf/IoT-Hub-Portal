---
title: Azure IoT Hub Portal API v1.0
language_tabs: []
toc_footers: []
includes: []
search: true
highlight_theme: darkula
headingLevel: 2

---

<!-- Generator: Widdershins v4.0.1 -->

<h1 id="azure-iot-hub-portal-api">Azure IoT Hub Portal API v1.0</h1>

> Scroll down for example requests and responses.

Available APIs for managing devices from Azure IoT Hub.

# Authentication

- HTTP Authentication, scheme: bearer 
    Specify the authorization token got from your IDP as a header.
    > Ex: ``Authorization: Bearer * ***``

<h1 id="azure-iot-hub-portal-api-iot-devices">IoT Devices</h1>

## GET Device list

<a id="opIdGET Device list"></a>

> Code samples

`GET /api/devices`

*Gets the device list.*

<h3 id="get-device-list-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|continuationToken|query|string|false|none|
|searchText|query|string|false|none|
|searchStatus|query|boolean|false|none|
|searchState|query|boolean|false|none|
|pageSize|query|integer(int32)|false|none|

> Example responses

> 200 Response

```
{"items":[{"deviceID":"string","deviceName":"string","imageUrl":"string","isConnected":true,"isEnabled":true,"supportLoRaFeatures":true,"statusUpdatedTime":"2019-08-24T14:15:22Z"}],"totalItems":0,"nextPage":"string"}
```

```json
{
  "items": [
    {
      "deviceID": "string",
      "deviceName": "string",
      "imageUrl": "string",
      "isConnected": true,
      "isEnabled": true,
      "supportLoRaFeatures": true,
      "statusUpdatedTime": "2019-08-24T14:15:22Z"
    }
  ],
  "totalItems": 0,
  "nextPage": "string"
}
```

<h3 id="get-device-list-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[DeviceListItemPaginationResult](#schemadevicelistitempaginationresult)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## POST Create device

<a id="opIdPOST Create device"></a>

> Code samples

`POST /api/devices`

*Creates the device.*

> Body parameter

```json
{
  "deviceID": "string",
  "deviceName": "string",
  "modelId": "string",
  "imageUrl": "string",
  "isConnected": true,
  "isEnabled": true,
  "statusUpdatedTime": "2019-08-24T14:15:22Z",
  "tags": {
    "property1": "string",
    "property2": "string"
  }
}
```

<h3 id="post-create-device-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[DeviceDetails](#schemadevicedetails)|false|The device.|

<h3 id="post-create-device-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## PUT Update device

<a id="opIdPUT Update device"></a>

> Code samples

`PUT /api/devices`

*Updates the device.*

> Body parameter

```json
{
  "deviceID": "string",
  "deviceName": "string",
  "modelId": "string",
  "imageUrl": "string",
  "isConnected": true,
  "isEnabled": true,
  "statusUpdatedTime": "2019-08-24T14:15:22Z",
  "tags": {
    "property1": "string",
    "property2": "string"
  }
}
```

<h3 id="put-update-device-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[DeviceDetails](#schemadevicedetails)|false|The device.|

<h3 id="put-update-device-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## GET Device details

<a id="opIdGET Device details"></a>

> Code samples

`GET /api/devices/{deviceID}`

*Gets the specified device.*

<h3 id="get-device-details-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|deviceID|path|string|true|The device identifier.|

> Example responses

> 200 Response

```
{"deviceID":"string","deviceName":"string","modelId":"string","imageUrl":"string","isConnected":true,"isEnabled":true,"statusUpdatedTime":"2019-08-24T14:15:22Z","tags":{"property1":"string","property2":"string"}}
```

```json
{
  "deviceID": "string",
  "deviceName": "string",
  "modelId": "string",
  "imageUrl": "string",
  "isConnected": true,
  "isEnabled": true,
  "statusUpdatedTime": "2019-08-24T14:15:22Z",
  "tags": {
    "property1": "string",
    "property2": "string"
  }
}
```

<h3 id="get-device-details-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[DeviceDetails](#schemadevicedetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## DELETE Remove device

<a id="opIdDELETE Remove device"></a>

> Code samples

`DELETE /api/devices/{deviceID}`

*Deletes the specified device.*

<h3 id="delete-remove-device-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|deviceID|path|string|true|The device identifier.|

<h3 id="delete-remove-device-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## GET Device Credentials

<a id="opIdGET Device Credentials"></a>

> Code samples

`GET /api/devices/{deviceID}/credentials`

*Gets the device credentials.*

<h3 id="get-device-credentials-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|deviceID|path|string|true|The device identifier.|

> Example responses

> 200 Response

```
{"registrationID":"string","symmetricKey":"string","scopeID":"string","provisioningEndpoint":"string"}
```

```json
{
  "registrationID": "string",
  "symmetricKey": "string",
  "scopeID": "string",
  "provisioningEndpoint": "string"
}
```

<h3 id="get-device-credentials-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[EnrollmentCredentials](#schemaenrollmentcredentials)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## GET Device Properties

<a id="opIdGET Device Properties"></a>

> Code samples

`GET /api/devices/{deviceID}/properties`

*Gets the device credentials.*

<h3 id="get-device-properties-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|deviceID|path|string|true|The device identifier.|

> Example responses

> 200 Response

```
[{"name":"string","displayName":"string","isWritable":true,"order":0,"propertyType":"Boolean","value":"string"}]
```

```json
[
  {
    "name": "string",
    "displayName": "string",
    "isWritable": true,
    "order": 0,
    "propertyType": "Boolean",
    "value": "string"
  }
]
```

<h3 id="get-device-properties-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|

<h3 id="get-device-properties-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[DevicePropertyValue](#schemadevicepropertyvalue)]|false|none|none|
|» name|string|true|none|The property name|
|» displayName|string|true|none|The property display name|
|» isWritable|boolean|true|none|Indicates whether the property is writable from the portal<br>> Note: if writable, the property is set to the desired properties of the device twin<br>>       otherwise, the property is read from the reported properties.|
|» order|integer(int32)|true|none|The property display order.|
|» propertyType|string|true|none|The device property type|
|» value|string¦null|false|none|The current property value.|

#### Enumerated Values

|Property|Value|
|---|---|
|propertyType|Boolean|
|propertyType|Double|
|propertyType|Float|
|propertyType|Integer|
|propertyType|Long|
|propertyType|String|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## POST Device Properties

<a id="opIdPOST Device Properties"></a>

> Code samples

`POST /api/devices/{deviceID}/properties`

*Gets the device credentials.*

> Body parameter

```json
[
  {
    "name": "string",
    "displayName": "string",
    "isWritable": true,
    "order": 0,
    "propertyType": "Boolean",
    "value": "string"
  }
]
```

<h3 id="post-device-properties-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|deviceID|path|string|true|The device identifier.|
|body|body|[DevicePropertyValue](#schemadevicepropertyvalue)|false|none|

> Example responses

> 200 Response

```
[{"name":"string","displayName":"string","isWritable":true,"order":0,"propertyType":"Boolean","value":"string"}]
```

```json
[
  {
    "name": "string",
    "displayName": "string",
    "isWritable": true,
    "order": 0,
    "propertyType": "Boolean",
    "value": "string"
  }
]
```

<h3 id="post-device-properties-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|

<h3 id="post-device-properties-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[DevicePropertyValue](#schemadevicepropertyvalue)]|false|none|none|
|» name|string|true|none|The property name|
|» displayName|string|true|none|The property display name|
|» isWritable|boolean|true|none|Indicates whether the property is writable from the portal<br>> Note: if writable, the property is set to the desired properties of the device twin<br>>       otherwise, the property is read from the reported properties.|
|» order|integer(int32)|true|none|The property display order.|
|» propertyType|string|true|none|The device property type|
|» value|string¦null|false|none|The current property value.|

#### Enumerated Values

|Property|Value|
|---|---|
|propertyType|Boolean|
|propertyType|Double|
|propertyType|Float|
|propertyType|Integer|
|propertyType|Long|
|propertyType|String|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

<h1 id="azure-iot-hub-portal-api-iot-edge">IoT Edge</h1>

## GET IoT Edge config list

<a id="opIdGET IoT Edge config list"></a>

> Code samples

`GET /api/edge/configurations`

*Gets the IoT Edge deployment configurations.*

> Example responses

> 200 Response

```
[{"configurationID":"string","conditions":"string","metricsTargeted":0,"metricsApplied":0,"metricsSuccess":0,"metricsFailure":0,"priority":0,"creationDate":"2019-08-24T14:15:22Z","modules":[{"moduleName":"string","version":"string","status":"string","environmentVariables":{"property1":"string","property2":"string"},"moduleIdentityTwinSettings":{"property1":"string","property2":"string"}}]}]
```

```json
[
  {
    "configurationID": "string",
    "conditions": "string",
    "metricsTargeted": 0,
    "metricsApplied": 0,
    "metricsSuccess": 0,
    "metricsFailure": 0,
    "priority": 0,
    "creationDate": "2019-08-24T14:15:22Z",
    "modules": [
      {
        "moduleName": "string",
        "version": "string",
        "status": "string",
        "environmentVariables": {
          "property1": "string",
          "property2": "string"
        },
        "moduleIdentityTwinSettings": {
          "property1": "string",
          "property2": "string"
        }
      }
    ]
  }
]
```

<h3 id="get-iot-edge-config-list-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|

<h3 id="get-iot-edge-config-list-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[ConfigListItem](#schemaconfiglistitem)]|false|none|none|
|» configurationID|string¦null|false|none|The IoT Edge configuration identifier.|
|» conditions|string¦null|false|none|The IoT Edge configuration target conditions.|
|» metricsTargeted|integer(int64)|false|none|The IoT Edge configuration targeted metrics.|
|» metricsApplied|integer(int64)|false|none|The IoT Edge configuration applied metrics.|
|» metricsSuccess|integer(int64)|false|none|The IoT Edge configuration success metrics.|
|» metricsFailure|integer(int64)|false|none|The IoT Edge configuration failure metrics.|
|» priority|integer(int32)|false|none|The IoT Edge configuration priority.|
|» creationDate|string(date-time)|false|none|The IoT Edge configuration creation date.|
|» modules|[[IoTEdgeModule](#schemaiotedgemodule)]¦null|false|none|The IoT Edge modules configuration.|
|»» moduleName|string|true|none|The module name.|
|»» version|string¦null|false|none|The module configuration version.|
|»» status|string¦null|false|none|The module status.|
|»» environmentVariables|object¦null|false|none|The module environment variables.|
|»»» **additionalProperties**|string¦null|false|none|none|
|»» moduleIdentityTwinSettings|object¦null|false|none|The module identity twin settings.|
|»»» **additionalProperties**|string¦null|false|none|none|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## GET IoT Edge configuration

<a id="opIdGET IoT Edge configuration"></a>

> Code samples

`GET /api/edge/configurations/{configurationID}`

*Gets the specified configuration.*

<h3 id="get-iot-edge-configuration-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|configurationID|path|string|true|The configuration identifier.|

> Example responses

> 200 Response

```
{"configurationID":"string","conditions":"string","metricsTargeted":0,"metricsApplied":0,"metricsSuccess":0,"metricsFailure":0,"priority":0,"creationDate":"2019-08-24T14:15:22Z","modules":[{"moduleName":"string","version":"string","status":"string","environmentVariables":{"property1":"string","property2":"string"},"moduleIdentityTwinSettings":{"property1":"string","property2":"string"}}]}
```

```json
{
  "configurationID": "string",
  "conditions": "string",
  "metricsTargeted": 0,
  "metricsApplied": 0,
  "metricsSuccess": 0,
  "metricsFailure": 0,
  "priority": 0,
  "creationDate": "2019-08-24T14:15:22Z",
  "modules": [
    {
      "moduleName": "string",
      "version": "string",
      "status": "string",
      "environmentVariables": {
        "property1": "string",
        "property2": "string"
      },
      "moduleIdentityTwinSettings": {
        "property1": "string",
        "property2": "string"
      }
    }
  ]
}
```

<h3 id="get-iot-edge-configuration-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[ConfigListItem](#schemaconfiglistitem)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## GET IoT Edge devices

<a id="opIdGET IoT Edge devices"></a>

> Code samples

`GET /api/edge/device`

*Gets the IoT Edge device list.*

<h3 id="get-iot-edge-devices-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|continuationToken|query|string|false|none|
|searchText|query|string|false|none|
|searchStatus|query|boolean|false|none|
|searchType|query|string|false|none|
|pageSize|query|integer(int32)|false|none|

> Example responses

> 200 Response

```
{"items":[{"deviceId":"string","status":"string","type":"string","nbDevices":0}],"totalItems":0,"nextPage":"string"}
```

```json
{
  "items": [
    {
      "deviceId": "string",
      "status": "string",
      "type": "string",
      "nbDevices": 0
    }
  ],
  "totalItems": 0,
  "nextPage": "string"
}
```

<h3 id="get-iot-edge-devices-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[IoTEdgeListItemPaginationResult](#schemaiotedgelistitempaginationresult)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## POST Create IoT Edge

<a id="opIdPOST Create IoT Edge"></a>

> Code samples

`POST /api/edge/device`

*Creates the IoT Edge device.*

> Body parameter

```json
{
  "deviceId": "string",
  "connectionState": "string",
  "scope": "string",
  "type": "string",
  "status": "string",
  "runtimeResponse": "string",
  "nbDevices": 0,
  "nbModules": 0,
  "environment": "string",
  "lastDeployment": {
    "name": "string",
    "dateCreation": "2019-08-24T14:15:22Z",
    "status": "string"
  },
  "modules": [
    {
      "moduleName": "string",
      "version": "string",
      "status": "string",
      "environmentVariables": {
        "property1": "string",
        "property2": "string"
      },
      "moduleIdentityTwinSettings": {
        "property1": "string",
        "property2": "string"
      }
    }
  ]
}
```

<h3 id="post-create-iot-edge-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[IoTEdgeDevice](#schemaiotedgedevice)|false|The IoT Edge device.|

> Example responses

> 400 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="post-create-iot-edge-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Bad Request|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## PUT Update IoT Edge

<a id="opIdPUT Update IoT Edge"></a>

> Code samples

`PUT /api/edge/device`

*Updates the device.*

> Body parameter

```json
{
  "deviceId": "string",
  "connectionState": "string",
  "scope": "string",
  "type": "string",
  "status": "string",
  "runtimeResponse": "string",
  "nbDevices": 0,
  "nbModules": 0,
  "environment": "string",
  "lastDeployment": {
    "name": "string",
    "dateCreation": "2019-08-24T14:15:22Z",
    "status": "string"
  },
  "modules": [
    {
      "moduleName": "string",
      "version": "string",
      "status": "string",
      "environmentVariables": {
        "property1": "string",
        "property2": "string"
      },
      "moduleIdentityTwinSettings": {
        "property1": "string",
        "property2": "string"
      }
    }
  ]
}
```

<h3 id="put-update-iot-edge-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[IoTEdgeDevice](#schemaiotedgedevice)|false|The IoT Edge device.|

<h3 id="put-update-iot-edge-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## GET IoT Edge device

<a id="opIdGET IoT Edge device"></a>

> Code samples

`GET /api/edge/device/{deviceId}`

*Gets the specified device.*

<h3 id="get-iot-edge-device-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|deviceId|path|string|true|The device identifier.|

> Example responses

> 200 Response

```
{"deviceId":"string","connectionState":"string","scope":"string","type":"string","status":"string","runtimeResponse":"string","nbDevices":0,"nbModules":0,"environment":"string","lastDeployment":{"name":"string","dateCreation":"2019-08-24T14:15:22Z","status":"string"},"modules":[{"moduleName":"string","version":"string","status":"string","environmentVariables":{"property1":"string","property2":"string"},"moduleIdentityTwinSettings":{"property1":"string","property2":"string"}}]}
```

```json
{
  "deviceId": "string",
  "connectionState": "string",
  "scope": "string",
  "type": "string",
  "status": "string",
  "runtimeResponse": "string",
  "nbDevices": 0,
  "nbModules": 0,
  "environment": "string",
  "lastDeployment": {
    "name": "string",
    "dateCreation": "2019-08-24T14:15:22Z",
    "status": "string"
  },
  "modules": [
    {
      "moduleName": "string",
      "version": "string",
      "status": "string",
      "environmentVariables": {
        "property1": "string",
        "property2": "string"
      },
      "moduleIdentityTwinSettings": {
        "property1": "string",
        "property2": "string"
      }
    }
  ]
}
```

<h3 id="get-iot-edge-device-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[IoTEdgeDevice](#schemaiotedgedevice)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## DELETE Remove IoT Edge

<a id="opIdDELETE Remove IoT Edge"></a>

> Code samples

`DELETE /api/edge/device/{deviceId}`

*Deletes the device.*

<h3 id="delete-remove-iot-edge-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|deviceId|path|string|true|The device identifier.|

<h3 id="delete-remove-iot-edge-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## POST Execute module command

<a id="opIdPOST Execute module command"></a>

> Code samples

`POST /api/edge/device/{deviceId}/{moduleId}/{methodName}`

*Executes the module method on the IoT Edge device.*

> Body parameter

```json
{
  "moduleName": "string",
  "version": "string",
  "status": "string",
  "environmentVariables": {
    "property1": "string",
    "property2": "string"
  },
  "moduleIdentityTwinSettings": {
    "property1": "string",
    "property2": "string"
  }
}
```

<h3 id="post-execute-module-command-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|deviceId|path|string|true|The device identifier.|
|methodName|path|string|true|Name of the method.|
|moduleId|path|string|true|none|
|body|body|[IoTEdgeModule](#schemaiotedgemodule)|false|The module.|

> Example responses

> 200 Response

```
{"payload":"string","status":0}
```

```json
{
  "payload": "string",
  "status": 0
}
```

<h3 id="post-execute-module-command-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[C2Dresult](#schemac2dresult)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## GET Device enrollment credentials

<a id="opIdGET Device enrollment credentials"></a>

> Code samples

`GET /api/edge/device/{deviceId}/credentials`

*Gets the IoT Edge device enrollement credentials.*

<h3 id="get-device-enrollment-credentials-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|deviceId|path|string|true|The device identifier.|

> Example responses

> 200 Response

```
{"registrationID":"string","symmetricKey":"string","scopeID":"string","provisioningEndpoint":"string"}
```

```json
{
  "registrationID": "string",
  "symmetricKey": "string",
  "scopeID": "string",
  "provisioningEndpoint": "string"
}
```

<h3 id="get-device-enrollment-credentials-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[EnrollmentCredentials](#schemaenrollmentcredentials)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

<h1 id="azure-iot-hub-portal-api-lora-wan">LoRa WAN</h1>

## GET LoRaWAN Concentrator list

<a id="opIdGET LoRaWAN Concentrator list"></a>

> Code samples

`GET /api/lorawan/concentrators`

*Gets all device concentrators.*

> Example responses

> 200 Response

```
{"items":[{"deviceId":"string","deviceName":"string","loraRegion":"string","deviceType":"string","clientCertificateThumbprint":"string","isConnected":true,"isEnabled":true,"alreadyLoggedInOnce":true,"routerConfig":{"netID":[0],"joinEui":[["string"]],"region":"string","hwspec":"string","freqRange":[0],"dRs":[[0]],"sx1301Conf":[{"property1":{"enable":true,"freq":0,"radio":0,"if":0,"bandwidth":0,"spreadFactor":0},"property2":{"enable":true,"freq":0,"radio":0,"if":0,"bandwidth":0,"spreadFactor":0}}],"nocca":true,"nodc":true,"nodwell":true}}],"totalItems":0,"nextPage":"string"}
```

```json
{
  "items": [
    {
      "deviceId": "string",
      "deviceName": "string",
      "loraRegion": "string",
      "deviceType": "string",
      "clientCertificateThumbprint": "string",
      "isConnected": true,
      "isEnabled": true,
      "alreadyLoggedInOnce": true,
      "routerConfig": {
        "netID": [
          0
        ],
        "joinEui": [
          [
            "string"
          ]
        ],
        "region": "string",
        "hwspec": "string",
        "freqRange": [
          0
        ],
        "dRs": [
          [
            0
          ]
        ],
        "sx1301Conf": [
          {
            "property1": {
              "enable": true,
              "freq": 0,
              "radio": 0,
              "if": 0,
              "bandwidth": 0,
              "spreadFactor": 0
            },
            "property2": {
              "enable": true,
              "freq": 0,
              "radio": 0,
              "if": 0,
              "bandwidth": 0,
              "spreadFactor": 0
            }
          }
        ],
        "nocca": true,
        "nodc": true,
        "nodwell": true
      }
    }
  ],
  "totalItems": 0,
  "nextPage": "string"
}
```

<h3 id="get-lorawan-concentrator-list-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[ConcentratorPaginationResult](#schemaconcentratorpaginationresult)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## POST Create LoRaWAN concentrator

<a id="opIdPOST Create LoRaWAN concentrator"></a>

> Code samples

`POST /api/lorawan/concentrators`

*Creates the device.*

> Body parameter

```json
{
  "deviceId": "string",
  "deviceName": "string",
  "loraRegion": "string",
  "deviceType": "string",
  "clientCertificateThumbprint": "string",
  "isConnected": true,
  "isEnabled": true,
  "alreadyLoggedInOnce": true,
  "routerConfig": {
    "netID": [
      0
    ],
    "joinEui": [
      [
        "string"
      ]
    ],
    "region": "string",
    "hwspec": "string",
    "freqRange": [
      0
    ],
    "dRs": [
      [
        0
      ]
    ],
    "sx1301Conf": [
      {
        "property1": {
          "enable": true,
          "freq": 0,
          "radio": 0,
          "if": 0,
          "bandwidth": 0,
          "spreadFactor": 0
        },
        "property2": {
          "enable": true,
          "freq": 0,
          "radio": 0,
          "if": 0,
          "bandwidth": 0,
          "spreadFactor": 0
        }
      }
    ],
    "nocca": true,
    "nodc": true,
    "nodwell": true
  }
}
```

<h3 id="post-create-lorawan-concentrator-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[Concentrator](#schemaconcentrator)|false|The device.|

> Example responses

> 400 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="post-create-lorawan-concentrator-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Bad Request|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## PUT Update LoRaWAN concentrator

<a id="opIdPUT Update LoRaWAN concentrator"></a>

> Code samples

`PUT /api/lorawan/concentrators`

*Updates the device.*

> Body parameter

```json
{
  "deviceId": "string",
  "deviceName": "string",
  "loraRegion": "string",
  "deviceType": "string",
  "clientCertificateThumbprint": "string",
  "isConnected": true,
  "isEnabled": true,
  "alreadyLoggedInOnce": true,
  "routerConfig": {
    "netID": [
      0
    ],
    "joinEui": [
      [
        "string"
      ]
    ],
    "region": "string",
    "hwspec": "string",
    "freqRange": [
      0
    ],
    "dRs": [
      [
        0
      ]
    ],
    "sx1301Conf": [
      {
        "property1": {
          "enable": true,
          "freq": 0,
          "radio": 0,
          "if": 0,
          "bandwidth": 0,
          "spreadFactor": 0
        },
        "property2": {
          "enable": true,
          "freq": 0,
          "radio": 0,
          "if": 0,
          "bandwidth": 0,
          "spreadFactor": 0
        }
      }
    ],
    "nocca": true,
    "nodc": true,
    "nodwell": true
  }
}
```

<h3 id="put-update-lorawan-concentrator-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[Concentrator](#schemaconcentrator)|false|The device.|

> Example responses

> 400 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="put-update-lorawan-concentrator-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Bad Request|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## GET LoRaWAN Concentrator

<a id="opIdGET LoRaWAN Concentrator"></a>

> Code samples

`GET /api/lorawan/concentrators/{deviceId}`

*Gets the device concentrator.*

<h3 id="get-lorawan-concentrator-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|deviceId|path|string|true|The device identifier.|

> Example responses

> 200 Response

```
{"deviceId":"string","deviceName":"string","loraRegion":"string","deviceType":"string","clientCertificateThumbprint":"string","isConnected":true,"isEnabled":true,"alreadyLoggedInOnce":true,"routerConfig":{"netID":[0],"joinEui":[["string"]],"region":"string","hwspec":"string","freqRange":[0],"dRs":[[0]],"sx1301Conf":[{"property1":{"enable":true,"freq":0,"radio":0,"if":0,"bandwidth":0,"spreadFactor":0},"property2":{"enable":true,"freq":0,"radio":0,"if":0,"bandwidth":0,"spreadFactor":0}}],"nocca":true,"nodc":true,"nodwell":true}}
```

```json
{
  "deviceId": "string",
  "deviceName": "string",
  "loraRegion": "string",
  "deviceType": "string",
  "clientCertificateThumbprint": "string",
  "isConnected": true,
  "isEnabled": true,
  "alreadyLoggedInOnce": true,
  "routerConfig": {
    "netID": [
      0
    ],
    "joinEui": [
      [
        "string"
      ]
    ],
    "region": "string",
    "hwspec": "string",
    "freqRange": [
      0
    ],
    "dRs": [
      [
        0
      ]
    ],
    "sx1301Conf": [
      {
        "property1": {
          "enable": true,
          "freq": 0,
          "radio": 0,
          "if": 0,
          "bandwidth": 0,
          "spreadFactor": 0
        },
        "property2": {
          "enable": true,
          "freq": 0,
          "radio": 0,
          "if": 0,
          "bandwidth": 0,
          "spreadFactor": 0
        }
      }
    ],
    "nocca": true,
    "nodc": true,
    "nodwell": true
  }
}
```

<h3 id="get-lorawan-concentrator-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[Concentrator](#schemaconcentrator)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## DELETE Remove LoRaWAN concentrator

<a id="opIdDELETE Remove LoRaWAN concentrator"></a>

> Code samples

`DELETE /api/lorawan/concentrators/{deviceId}`

*Deletes the specified device.*

<h3 id="delete-remove-lorawan-concentrator-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|deviceId|path|string|true|The device identifier.|

<h3 id="delete-remove-lorawan-concentrator-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## GET LoRaWAN device list

<a id="opIdGET LoRaWAN device list"></a>

> Code samples

`GET /api/lorawan/devices`

*Gets the device list.*

<h3 id="get-lorawan-device-list-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|continuationToken|query|string|false|none|
|searchText|query|string|false|none|
|searchStatus|query|boolean|false|none|
|searchState|query|boolean|false|none|
|pageSize|query|integer(int32)|false|none|

> Example responses

> 200 Response

```
{"items":[{"deviceID":"string","deviceName":"string","imageUrl":"string","isConnected":true,"isEnabled":true,"supportLoRaFeatures":true,"statusUpdatedTime":"2019-08-24T14:15:22Z"}],"totalItems":0,"nextPage":"string"}
```

```json
{
  "items": [
    {
      "deviceID": "string",
      "deviceName": "string",
      "imageUrl": "string",
      "isConnected": true,
      "isEnabled": true,
      "supportLoRaFeatures": true,
      "statusUpdatedTime": "2019-08-24T14:15:22Z"
    }
  ],
  "totalItems": 0,
  "nextPage": "string"
}
```

<h3 id="get-lorawan-device-list-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[DeviceListItemPaginationResult](#schemadevicelistitempaginationresult)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## POST Create LoRaWAN device

<a id="opIdPOST Create LoRaWAN device"></a>

> Code samples

`POST /api/lorawan/devices`

*Creates the device.*

> Body parameter

```json
{
  "deviceID": "string",
  "deviceName": "string",
  "modelId": "string",
  "imageUrl": "string",
  "isConnected": true,
  "isEnabled": true,
  "statusUpdatedTime": "2019-08-24T14:15:22Z",
  "tags": {
    "property1": "string",
    "property2": "string"
  },
  "classType": "A",
  "useOTAA": true,
  "appEUI": "string",
  "sensorDecoder": "string",
  "gatewayID": "string",
  "downlink": true,
  "preferredWindow": 0,
  "deduplication": "None",
  "rX1DROffset": 0,
  "rX2DataRate": 0,
  "rxDelay": 0,
  "abpRelaxMode": true,
  "fCntUpStart": 4294967295,
  "fCntDownStart": 4294967295,
  "supports32BitFCnt": true,
  "fCntResetCounter": 4294967295,
  "keepAliveTimeout": 0,
  "appKey": "string",
  "appSKey": "string",
  "nwkSKey": "string",
  "devAddr": "string",
  "alreadyLoggedInOnce": true,
  "dataRate": "string",
  "txPower": "string",
  "nbRep": "string",
  "reportedRX2DataRate": "string",
  "reportedRX1DROffset": "string",
  "reportedRXDelay": "string"
}
```

<h3 id="post-create-lorawan-device-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[LoRaDeviceDetails](#schemaloradevicedetails)|false|The device.|

<h3 id="post-create-lorawan-device-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## PUT Update LoRaWAN device

<a id="opIdPUT Update LoRaWAN device"></a>

> Code samples

`PUT /api/lorawan/devices`

*Updates the device.*

> Body parameter

```json
{
  "deviceID": "string",
  "deviceName": "string",
  "modelId": "string",
  "imageUrl": "string",
  "isConnected": true,
  "isEnabled": true,
  "statusUpdatedTime": "2019-08-24T14:15:22Z",
  "tags": {
    "property1": "string",
    "property2": "string"
  },
  "classType": "A",
  "useOTAA": true,
  "appEUI": "string",
  "sensorDecoder": "string",
  "gatewayID": "string",
  "downlink": true,
  "preferredWindow": 0,
  "deduplication": "None",
  "rX1DROffset": 0,
  "rX2DataRate": 0,
  "rxDelay": 0,
  "abpRelaxMode": true,
  "fCntUpStart": 4294967295,
  "fCntDownStart": 4294967295,
  "supports32BitFCnt": true,
  "fCntResetCounter": 4294967295,
  "keepAliveTimeout": 0,
  "appKey": "string",
  "appSKey": "string",
  "nwkSKey": "string",
  "devAddr": "string",
  "alreadyLoggedInOnce": true,
  "dataRate": "string",
  "txPower": "string",
  "nbRep": "string",
  "reportedRX2DataRate": "string",
  "reportedRX1DROffset": "string",
  "reportedRXDelay": "string"
}
```

<h3 id="put-update-lorawan-device-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[LoRaDeviceDetails](#schemaloradevicedetails)|false|The device.|

<h3 id="put-update-lorawan-device-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## GET LoRaWAN device details

<a id="opIdGET LoRaWAN device details"></a>

> Code samples

`GET /api/lorawan/devices/{deviceID}`

*Gets the specified device.*

<h3 id="get-lorawan-device-details-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|deviceID|path|string|true|The device identifier.|

> Example responses

> 200 Response

```
{"deviceID":"string","deviceName":"string","modelId":"string","imageUrl":"string","isConnected":true,"isEnabled":true,"statusUpdatedTime":"2019-08-24T14:15:22Z","tags":{"property1":"string","property2":"string"},"classType":"A","useOTAA":true,"appEUI":"string","sensorDecoder":"string","gatewayID":"string","downlink":true,"preferredWindow":0,"deduplication":"None","rX1DROffset":0,"rX2DataRate":0,"rxDelay":0,"abpRelaxMode":true,"fCntUpStart":4294967295,"fCntDownStart":4294967295,"supports32BitFCnt":true,"fCntResetCounter":4294967295,"keepAliveTimeout":0,"appKey":"string","appSKey":"string","nwkSKey":"string","devAddr":"string","alreadyLoggedInOnce":true,"dataRate":"string","txPower":"string","nbRep":"string","reportedRX2DataRate":"string","reportedRX1DROffset":"string","reportedRXDelay":"string"}
```

```json
{
  "deviceID": "string",
  "deviceName": "string",
  "modelId": "string",
  "imageUrl": "string",
  "isConnected": true,
  "isEnabled": true,
  "statusUpdatedTime": "2019-08-24T14:15:22Z",
  "tags": {
    "property1": "string",
    "property2": "string"
  },
  "classType": "A",
  "useOTAA": true,
  "appEUI": "string",
  "sensorDecoder": "string",
  "gatewayID": "string",
  "downlink": true,
  "preferredWindow": 0,
  "deduplication": "None",
  "rX1DROffset": 0,
  "rX2DataRate": 0,
  "rxDelay": 0,
  "abpRelaxMode": true,
  "fCntUpStart": 4294967295,
  "fCntDownStart": 4294967295,
  "supports32BitFCnt": true,
  "fCntResetCounter": 4294967295,
  "keepAliveTimeout": 0,
  "appKey": "string",
  "appSKey": "string",
  "nwkSKey": "string",
  "devAddr": "string",
  "alreadyLoggedInOnce": true,
  "dataRate": "string",
  "txPower": "string",
  "nbRep": "string",
  "reportedRX2DataRate": "string",
  "reportedRX1DROffset": "string",
  "reportedRXDelay": "string"
}
```

<h3 id="get-lorawan-device-details-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[LoRaDeviceDetails](#schemaloradevicedetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## DELETE Remove LoRaWAN device

<a id="opIdDELETE Remove LoRaWAN device"></a>

> Code samples

`DELETE /api/lorawan/devices/{deviceID}`

*Deletes the specified device.*

<h3 id="delete-remove-lorawan-device-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|deviceID|path|string|true|The device identifier.|

<h3 id="delete-remove-lorawan-device-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## POST Execute LoRaWAN command

<a id="opIdPOST Execute LoRaWAN command"></a>

> Code samples

`POST /api/lorawan/devices/{deviceId}/_command/{commandId}`

*Executes the command on the device..*

<h3 id="post-execute-lorawan-command-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|deviceId|path|string|true|The device identifier.|
|commandId|path|string|true|The command identifier.|

<h3 id="post-execute-lorawan-command-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## GET LoRaWAN device model list

<a id="opIdGET LoRaWAN device model list"></a>

> Code samples

`GET /api/lorawan/models`

*Gets the device model list.*

> Example responses

> 200 Response

```
[{"modelId":"string","imageUrl":"string","name":"string","description":"string","isBuiltin":true,"supportLoRaFeatures":true}]
```

```json
[
  {
    "modelId": "string",
    "imageUrl": "string",
    "name": "string",
    "description": "string",
    "isBuiltin": true,
    "supportLoRaFeatures": true
  }
]
```

<h3 id="get-lorawan-device-model-list-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|

<h3 id="get-lorawan-device-model-list-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[DeviceModel](#schemadevicemodel)]|false|none|none|
|» modelId|string¦null|false|none|The device model identifier.|
|» imageUrl|string¦null|false|none|The device model image Url.|
|» name|string|true|none|The device model name.|
|» description|string¦null|false|none|The device model description.|
|» isBuiltin|boolean|false|none|A value indicating whether this instance is builtin.|
|» supportLoRaFeatures|boolean|false|none|A value indicating whether the LoRa features is supported on this model.|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## POST Create a new LoRaWAN device model

<a id="opIdPOST Create a new LoRaWAN device model"></a>

> Code samples

`POST /api/lorawan/models`

*Creates the specified device model.*

> Body parameter

```json
{
  "modelId": "string",
  "imageUrl": "string",
  "name": "string",
  "description": "string",
  "isBuiltin": true,
  "supportLoRaFeatures": true,
  "classType": "A",
  "useOTAA": true,
  "appEUI": "string",
  "sensorDecoder": "string",
  "downlink": true,
  "preferredWindow": 0,
  "deduplication": "None",
  "rX1DROffset": 0,
  "rX2DataRate": 0,
  "rxDelay": 0,
  "abpRelaxMode": true,
  "fCntUpStart": 4294967295,
  "fCntDownStart": 4294967295,
  "fCntResetCounter": 4294967295,
  "supports32BitFCnt": true,
  "keepAliveTimeout": 0
}
```

<h3 id="post-create-a-new-lorawan-device-model-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[LoRaDeviceModel](#schemaloradevicemodel)|false|The device model.|

> Example responses

> 400 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="post-create-a-new-lorawan-device-model-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Bad Request|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## GET LoRaWAN device model

<a id="opIdGET LoRaWAN device model"></a>

> Code samples

`GET /api/lorawan/models/{id}`

*Get the device model details.*

<h3 id="get-lorawan-device-model-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string|true|The devic emodel identifier.|

> Example responses

> 200 Response

```
{"modelId":"string","imageUrl":"string","name":"string","description":"string","isBuiltin":true,"supportLoRaFeatures":true,"classType":"A","useOTAA":true,"appEUI":"string","sensorDecoder":"string","downlink":true,"preferredWindow":0,"deduplication":"None","rX1DROffset":0,"rX2DataRate":0,"rxDelay":0,"abpRelaxMode":true,"fCntUpStart":4294967295,"fCntDownStart":4294967295,"fCntResetCounter":4294967295,"supports32BitFCnt":true,"keepAliveTimeout":0}
```

```json
{
  "modelId": "string",
  "imageUrl": "string",
  "name": "string",
  "description": "string",
  "isBuiltin": true,
  "supportLoRaFeatures": true,
  "classType": "A",
  "useOTAA": true,
  "appEUI": "string",
  "sensorDecoder": "string",
  "downlink": true,
  "preferredWindow": 0,
  "deduplication": "None",
  "rX1DROffset": 0,
  "rX2DataRate": 0,
  "rxDelay": 0,
  "abpRelaxMode": true,
  "fCntUpStart": 4294967295,
  "fCntDownStart": 4294967295,
  "fCntResetCounter": 4294967295,
  "supports32BitFCnt": true,
  "keepAliveTimeout": 0
}
```

<h3 id="get-lorawan-device-model-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[LoRaDeviceModel](#schemaloradevicemodel)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## PUT Update the LoRaWAN device model

<a id="opIdPUT Update the LoRaWAN device model"></a>

> Code samples

`PUT /api/lorawan/models/{id}`

*Updates the specified device model.*

> Body parameter

```json
{
  "modelId": "string",
  "imageUrl": "string",
  "name": "string",
  "description": "string",
  "isBuiltin": true,
  "supportLoRaFeatures": true,
  "classType": "A",
  "useOTAA": true,
  "appEUI": "string",
  "sensorDecoder": "string",
  "downlink": true,
  "preferredWindow": 0,
  "deduplication": "None",
  "rX1DROffset": 0,
  "rX2DataRate": 0,
  "rxDelay": 0,
  "abpRelaxMode": true,
  "fCntUpStart": 4294967295,
  "fCntDownStart": 4294967295,
  "fCntResetCounter": 4294967295,
  "supports32BitFCnt": true,
  "keepAliveTimeout": 0
}
```

<h3 id="put-update-the-lorawan-device-model-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string|true|none|
|body|body|[LoRaDeviceModel](#schemaloradevicemodel)|false|The device model.|

> Example responses

> 400 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="put-update-the-lorawan-device-model-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Bad Request|[ProblemDetails](#schemaproblemdetails)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## DELETE Remove the LoRaWAN device model

<a id="opIdDELETE Remove the LoRaWAN device model"></a>

> Code samples

`DELETE /api/lorawan/models/{id}`

*Deletes the specified device model.*

<h3 id="delete-remove-the-lorawan-device-model-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string|true|The device model identifier.|

> Example responses

> 400 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="delete-remove-the-lorawan-device-model-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|No Content|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Bad Request|[ProblemDetails](#schemaproblemdetails)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## GET LoRaWAN device model avatar URL

<a id="opIdGET LoRaWAN device model avatar URL"></a>

> Code samples

`GET /api/lorawan/models/{id}/avatar`

*Gets the device model avatar.*

<h3 id="get-lorawan-device-model-avatar-url-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string|true|The device model identifier|

> Example responses

> 200 Response

```
"string"
```

```json
"string"
```

<h3 id="get-lorawan-device-model-avatar-url-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|string|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## POST Update the LoRaWAN device model avatar

<a id="opIdPOST Update the LoRaWAN device model avatar"></a>

> Code samples

`POST /api/lorawan/models/{id}/avatar`

*Changes the avatar.*

> Body parameter

```yaml
file: string

```

<h3 id="post-update-the-lorawan-device-model-avatar-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string|true|The model identifier.|
|body|body|object|false|none|
|» file|body|string(binary)|false|none|

> Example responses

> 200 Response

```
"string"
```

```json
"string"
```

<h3 id="post-update-the-lorawan-device-model-avatar-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|string|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## DELETE Remove the LoRaWAN device model avatar

<a id="opIdDELETE Remove the LoRaWAN device model avatar"></a>

> Code samples

`DELETE /api/lorawan/models/{id}/avatar`

*Deletes the avatar.*

<h3 id="delete-remove-the-lorawan-device-model-avatar-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string|true|The model identifier.|

> Example responses

> 404 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="delete-remove-the-lorawan-device-model-avatar-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|No Content|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## POST Set device model commands

<a id="opIdPOST Set device model commands"></a>

> Code samples

`POST /api/lorawan/models/{id}/commands`

*Updates the device model's commands.*

> Body parameter

```json
[
  {
    "name": "string",
    "frame": "string",
    "port": 1,
    "isBuiltin": true
  }
]
```

<h3 id="post-set-device-model-commands-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string|true|The model identifier.|
|body|body|[DeviceModelCommand](#schemadevicemodelcommand)|false|The commands.|

> Example responses

> 404 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="post-set-device-model-commands-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## GET Device model commands

<a id="opIdGET Device model commands"></a>

> Code samples

`GET /api/lorawan/models/{id}/commands`

*Gets the device model's commands.*

<h3 id="get-device-model-commands-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string|true|The model identifier.|

> Example responses

> 200 Response

```
[{"name":"string","frame":"string","port":1,"isBuiltin":true}]
```

```json
[
  {
    "name": "string",
    "frame": "string",
    "port": 1,
    "isBuiltin": true
  }
]
```

<h3 id="get-device-model-commands-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<h3 id="get-device-model-commands-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[DeviceModelCommand](#schemadevicemodelcommand)]|false|none|none|
|» name|string|true|none|The command name.|
|» frame|string|true|none|The command frame in hexa.|
|» port|integer(int32)|true|none|The LoRa WAN port.|
|» isBuiltin|boolean|false|none|A value indicating whether this instance is builtin.|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

<h1 id="azure-iot-hub-portal-api-device-models">Device Models</h1>

## GET Device model list

<a id="opIdGET Device model list"></a>

> Code samples

`GET /api/models`

*Gets the device model list.*

> Example responses

> 200 Response

```
[{"modelId":"string","imageUrl":"string","name":"string","description":"string","isBuiltin":true,"supportLoRaFeatures":true}]
```

```json
[
  {
    "modelId": "string",
    "imageUrl": "string",
    "name": "string",
    "description": "string",
    "isBuiltin": true,
    "supportLoRaFeatures": true
  }
]
```

<h3 id="get-device-model-list-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|

<h3 id="get-device-model-list-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[DeviceModel](#schemadevicemodel)]|false|none|none|
|» modelId|string¦null|false|none|The device model identifier.|
|» imageUrl|string¦null|false|none|The device model image Url.|
|» name|string|true|none|The device model name.|
|» description|string¦null|false|none|The device model description.|
|» isBuiltin|boolean|false|none|A value indicating whether this instance is builtin.|
|» supportLoRaFeatures|boolean|false|none|A value indicating whether the LoRa features is supported on this model.|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## POST Create a new device model

<a id="opIdPOST Create a new device model"></a>

> Code samples

`POST /api/models`

*Creates the specified device model.*

> Body parameter

```json
{
  "modelId": "string",
  "imageUrl": "string",
  "name": "string",
  "description": "string",
  "isBuiltin": true,
  "supportLoRaFeatures": true
}
```

<h3 id="post-create-a-new-device-model-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[DeviceModel](#schemadevicemodel)|false|The device model.|

> Example responses

> 400 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="post-create-a-new-device-model-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Bad Request|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## GET Device model

<a id="opIdGET Device model"></a>

> Code samples

`GET /api/models/{id}`

*Get the device model details.*

<h3 id="get-device-model-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string|true|The devic emodel identifier.|

> Example responses

> 200 Response

```
{"modelId":"string","imageUrl":"string","name":"string","description":"string","isBuiltin":true,"supportLoRaFeatures":true}
```

```json
{
  "modelId": "string",
  "imageUrl": "string",
  "name": "string",
  "description": "string",
  "isBuiltin": true,
  "supportLoRaFeatures": true
}
```

<h3 id="get-device-model-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[DeviceModel](#schemadevicemodel)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## PUT Update the device model

<a id="opIdPUT Update the device model"></a>

> Code samples

`PUT /api/models/{id}`

*Updates the specified device model.*

> Body parameter

```json
{
  "modelId": "string",
  "imageUrl": "string",
  "name": "string",
  "description": "string",
  "isBuiltin": true,
  "supportLoRaFeatures": true
}
```

<h3 id="put-update-the-device-model-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string|true|none|
|body|body|[DeviceModel](#schemadevicemodel)|false|The device model.|

> Example responses

> 400 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="put-update-the-device-model-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Bad Request|[ProblemDetails](#schemaproblemdetails)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## DELETE Remove the device model

<a id="opIdDELETE Remove the device model"></a>

> Code samples

`DELETE /api/models/{id}`

*Deletes the specified device model.*

<h3 id="delete-remove-the-device-model-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string|true|The device model identifier.|

> Example responses

> 400 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="delete-remove-the-device-model-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|No Content|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Bad Request|[ProblemDetails](#schemaproblemdetails)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## GET Device model avatar URL

<a id="opIdGET Device model avatar URL"></a>

> Code samples

`GET /api/models/{id}/avatar`

*Gets the device model avatar.*

<h3 id="get-device-model-avatar-url-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string|true|The device model identifier|

> Example responses

> 200 Response

```
"string"
```

```json
"string"
```

<h3 id="get-device-model-avatar-url-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|string|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## POST Update the device model avatar

<a id="opIdPOST Update the device model avatar"></a>

> Code samples

`POST /api/models/{id}/avatar`

*Changes the avatar.*

> Body parameter

```yaml
file: string

```

<h3 id="post-update-the-device-model-avatar-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string|true|The model identifier.|
|body|body|object|false|none|
|» file|body|string(binary)|false|none|

> Example responses

> 200 Response

```
"string"
```

```json
"string"
```

<h3 id="post-update-the-device-model-avatar-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|string|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## DELETE Remove the device model avatar

<a id="opIdDELETE Remove the device model avatar"></a>

> Code samples

`DELETE /api/models/{id}/avatar`

*Deletes the avatar.*

<h3 id="delete-remove-the-device-model-avatar-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string|true|The model identifier.|

> Example responses

> 404 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="delete-remove-the-device-model-avatar-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|No Content|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## GET Device model properties

<a id="opIdGET Device model properties"></a>

> Code samples

`GET /api/models/{id}/properties`

*Gets the device model properties.*

<h3 id="get-device-model-properties-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string|true|The device model properties|

> Example responses

> 200 Response

```
[{"name":"string","displayName":"string","isWritable":true,"order":0,"propertyType":"Boolean"}]
```

```json
[
  {
    "name": "string",
    "displayName": "string",
    "isWritable": true,
    "order": 0,
    "propertyType": "Boolean"
  }
]
```

<h3 id="get-device-model-properties-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<h3 id="get-device-model-properties-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[DeviceProperty](#schemadeviceproperty)]|false|none|none|
|» name|string|true|none|The property name|
|» displayName|string|true|none|The property display name|
|» isWritable|boolean|true|none|Indicates whether the property is writable from the portal<br>> Note: if writable, the property is set to the desired properties of the device twin<br>>       otherwise, the property is read from the reported properties.|
|» order|integer(int32)|true|none|The property display order.|
|» propertyType|string|true|none|The device property type|

#### Enumerated Values

|Property|Value|
|---|---|
|propertyType|Boolean|
|propertyType|Double|
|propertyType|Float|
|propertyType|Integer|
|propertyType|Long|
|propertyType|String|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## POST Device model properties

<a id="opIdPOST Device model properties"></a>

> Code samples

`POST /api/models/{id}/properties`

*Sets the device model properties.*

> Body parameter

```json
[
  {
    "name": "string",
    "displayName": "string",
    "isWritable": true,
    "order": 0,
    "propertyType": "Boolean"
  }
]
```

<h3 id="post-device-model-properties-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string|true|The device model properties|
|body|body|[DeviceProperty](#schemadeviceproperty)|false|The model properties|

> Example responses

> 404 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="post-device-model-properties-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

<h1 id="azure-iot-hub-portal-api-portal-settings">Portal Settings</h1>

## POST Update the Device tags settings

<a id="opIdPOST Update the Device tags settings"></a>

> Code samples

`POST /api/settings/device-tags`

*Updates the device tag settings to be used in the application.*

> Body parameter

```json
[
  {
    "name": "string",
    "label": "string",
    "required": true,
    "searchable": true
  }
]
```

<h3 id="post-update-the-device-tags-settings-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[DeviceTag](#schemadevicetag)|false|List of tags.|

<h3 id="post-update-the-device-tags-settings-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## GET Device tags settings

<a id="opIdGET Device tags settings"></a>

> Code samples

`GET /api/settings/device-tags`

*Gets the device tag settings to be used in the application*

> Example responses

> 200 Response

```json
[
  {
    "name": "string",
    "label": "string",
    "required": true,
    "searchable": true
  }
]
```

<h3 id="get-device-tags-settings-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|

<h3 id="get-device-tags-settings-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[DeviceTag](#schemadevicetag)]|false|none|none|
|» name|string|true|none|The registered name in the device twin.|
|» label|string|true|none|The label shown to the user.|
|» required|boolean|false|none|Whether the field is required when creating a new device or not.|
|» searchable|boolean|false|none|Whether the field can be searcheable via the device search panel or not.|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## GET Open ID settings

<a id="opIdGET Open ID settings"></a>

> Code samples

`GET /api/settings/oidc`

*Get the Open ID Settings.*

<h3 id="get-open-id-settings-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Returns the OIDC settings.|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Internal server error.|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

## GET Portal settings

<a id="opIdGET Portal settings"></a>

> Code samples

`GET /api/settings/portal`

*Get the portal settings.*

> Example responses

> 200 Response

```json
{
  "isLoRaSupported": true,
  "version": "string",
  "portalName": "string"
}
```

<h3 id="get-portal-settings-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[PortalSettings](#schemaportalsettings)|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|None|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
None
</aside>

# Schemas

<h2 id="tocS_C2Dresult">C2Dresult</h2>
<!-- backwards compatibility -->
<a id="schemac2dresult"></a>
<a id="schema_C2Dresult"></a>
<a id="tocSc2dresult"></a>
<a id="tocsc2dresult"></a>

```json
{
  "payload": "string",
  "status": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|payload|string¦null|false|none|The C2D result payload.|
|status|integer(int32)|false|none|The C2D status.|

<h2 id="tocS_Channel">Channel</h2>
<!-- backwards compatibility -->
<a id="schemachannel"></a>
<a id="schema_Channel"></a>
<a id="tocSchannel"></a>
<a id="tocschannel"></a>

```json
{
  "enable": true,
  "freq": 0,
  "radio": 0,
  "if": 0,
  "bandwidth": 0,
  "spreadFactor": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|enable|boolean¦null|false|none|A value indicating whether the channel is enabled.|
|freq|integer(int32)|false|none|The frequency.|
|radio|integer(int32)|false|none|The radio.|
|if|integer(int32)|false|none|The interface.|
|bandwidth|integer(int32)|false|none|The bandwidth.|
|spreadFactor|integer(int32)|false|none|The spread factor.|

<h2 id="tocS_Concentrator">Concentrator</h2>
<!-- backwards compatibility -->
<a id="schemaconcentrator"></a>
<a id="schema_Concentrator"></a>
<a id="tocSconcentrator"></a>
<a id="tocsconcentrator"></a>

```json
{
  "deviceId": "string",
  "deviceName": "string",
  "loraRegion": "string",
  "deviceType": "string",
  "clientCertificateThumbprint": "string",
  "isConnected": true,
  "isEnabled": true,
  "alreadyLoggedInOnce": true,
  "routerConfig": {
    "netID": [
      0
    ],
    "joinEui": [
      [
        "string"
      ]
    ],
    "region": "string",
    "hwspec": "string",
    "freqRange": [
      0
    ],
    "dRs": [
      [
        0
      ]
    ],
    "sx1301Conf": [
      {
        "property1": {
          "enable": true,
          "freq": 0,
          "radio": 0,
          "if": 0,
          "bandwidth": 0,
          "spreadFactor": 0
        },
        "property2": {
          "enable": true,
          "freq": 0,
          "radio": 0,
          "if": 0,
          "bandwidth": 0,
          "spreadFactor": 0
        }
      }
    ],
    "nocca": true,
    "nodc": true,
    "nodwell": true
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|deviceId|string|true|none|The device identifier.|
|deviceName|string|true|none|The name of the device.|
|loraRegion|string|true|none|The lora region.|
|deviceType|string¦null|false|none|The type of the device.|
|clientCertificateThumbprint|string¦null|false|none|The client certificate thumbprint.|
|isConnected|boolean|false|none|`true` if this instance is connected; otherwise, `false`.|
|isEnabled|boolean|false|none|`true` if this instance is enabled; otherwise, `false`.|
|alreadyLoggedInOnce|boolean|false|none|`true` if [already logged in once]; otherwise, `false`.|
|routerConfig|[RouterConfig](#schemarouterconfig)|false|none|none|

<h2 id="tocS_ConcentratorPaginationResult">ConcentratorPaginationResult</h2>
<!-- backwards compatibility -->
<a id="schemaconcentratorpaginationresult"></a>
<a id="schema_ConcentratorPaginationResult"></a>
<a id="tocSconcentratorpaginationresult"></a>
<a id="tocsconcentratorpaginationresult"></a>

```json
{
  "items": [
    {
      "deviceId": "string",
      "deviceName": "string",
      "loraRegion": "string",
      "deviceType": "string",
      "clientCertificateThumbprint": "string",
      "isConnected": true,
      "isEnabled": true,
      "alreadyLoggedInOnce": true,
      "routerConfig": {
        "netID": [
          0
        ],
        "joinEui": [
          [
            "string"
          ]
        ],
        "region": "string",
        "hwspec": "string",
        "freqRange": [
          0
        ],
        "dRs": [
          [
            0
          ]
        ],
        "sx1301Conf": [
          {
            "property1": {
              "enable": true,
              "freq": 0,
              "radio": 0,
              "if": 0,
              "bandwidth": 0,
              "spreadFactor": 0
            },
            "property2": {
              "enable": true,
              "freq": 0,
              "radio": 0,
              "if": 0,
              "bandwidth": 0,
              "spreadFactor": 0
            }
          }
        ],
        "nocca": true,
        "nodc": true,
        "nodwell": true
      }
    }
  ],
  "totalItems": 0,
  "nextPage": "string"
}

```

Class representing the page results.

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|items|[[Concentrator](#schemaconcentrator)]¦null|false|none|The current page items.|
|totalItems|integer(int32)|false|none|The total number of items.|
|nextPage|string¦null|false|none|The query next page Url.|

<h2 id="tocS_ConfigItem">ConfigItem</h2>
<!-- backwards compatibility -->
<a id="schemaconfigitem"></a>
<a id="schema_ConfigItem"></a>
<a id="tocSconfigitem"></a>
<a id="tocsconfigitem"></a>

```json
{
  "name": "string",
  "dateCreation": "2019-08-24T14:15:22Z",
  "status": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|name|string|true|none|The IoT Edge configuration name.|
|dateCreation|string(date-time)|false|none|The IoT Edge configuration creation date.|
|status|string¦null|false|none|The IoT Edge configuration status.|

<h2 id="tocS_ConfigListItem">ConfigListItem</h2>
<!-- backwards compatibility -->
<a id="schemaconfiglistitem"></a>
<a id="schema_ConfigListItem"></a>
<a id="tocSconfiglistitem"></a>
<a id="tocsconfiglistitem"></a>

```json
{
  "configurationID": "string",
  "conditions": "string",
  "metricsTargeted": 0,
  "metricsApplied": 0,
  "metricsSuccess": 0,
  "metricsFailure": 0,
  "priority": 0,
  "creationDate": "2019-08-24T14:15:22Z",
  "modules": [
    {
      "moduleName": "string",
      "version": "string",
      "status": "string",
      "environmentVariables": {
        "property1": "string",
        "property2": "string"
      },
      "moduleIdentityTwinSettings": {
        "property1": "string",
        "property2": "string"
      }
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|configurationID|string¦null|false|none|The IoT Edge configuration identifier.|
|conditions|string¦null|false|none|The IoT Edge configuration target conditions.|
|metricsTargeted|integer(int64)|false|none|The IoT Edge configuration targeted metrics.|
|metricsApplied|integer(int64)|false|none|The IoT Edge configuration applied metrics.|
|metricsSuccess|integer(int64)|false|none|The IoT Edge configuration success metrics.|
|metricsFailure|integer(int64)|false|none|The IoT Edge configuration failure metrics.|
|priority|integer(int32)|false|none|The IoT Edge configuration priority.|
|creationDate|string(date-time)|false|none|The IoT Edge configuration creation date.|
|modules|[[IoTEdgeModule](#schemaiotedgemodule)]¦null|false|none|The IoT Edge modules configuration.|

<h2 id="tocS_DeviceDetails">DeviceDetails</h2>
<!-- backwards compatibility -->
<a id="schemadevicedetails"></a>
<a id="schema_DeviceDetails"></a>
<a id="tocSdevicedetails"></a>
<a id="tocsdevicedetails"></a>

```json
{
  "deviceID": "string",
  "deviceName": "string",
  "modelId": "string",
  "imageUrl": "string",
  "isConnected": true,
  "isEnabled": true,
  "statusUpdatedTime": "2019-08-24T14:15:22Z",
  "tags": {
    "property1": "string",
    "property2": "string"
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|deviceID|string|true|none|The device identifier.|
|deviceName|string|true|none|The name of the device.|
|modelId|string|true|none|The model identifier.|
|imageUrl|string¦null|false|none|The device model image Url.|
|isConnected|boolean|false|none|`true` if this instance is connected; otherwise, `false`.|
|isEnabled|boolean|false|none|`true` if this instance is enabled; otherwise, `false`.|
|statusUpdatedTime|string(date-time)|false|none|The status updated time.|
|tags|object¦null|false|none|List of custom device tags and their values.|
|» **additionalProperties**|string¦null|false|none|none|

<h2 id="tocS_DeviceListItem">DeviceListItem</h2>
<!-- backwards compatibility -->
<a id="schemadevicelistitem"></a>
<a id="schema_DeviceListItem"></a>
<a id="tocSdevicelistitem"></a>
<a id="tocsdevicelistitem"></a>

```json
{
  "deviceID": "string",
  "deviceName": "string",
  "imageUrl": "string",
  "isConnected": true,
  "isEnabled": true,
  "supportLoRaFeatures": true,
  "statusUpdatedTime": "2019-08-24T14:15:22Z"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|deviceID|string¦null|false|none|The device Identifier.|
|deviceName|string¦null|false|none|The device friendly name.|
|imageUrl|string¦null|false|none|The device model image Url.|
|isConnected|boolean|false|none|A value indicating whether the device is currently connected.|
|isEnabled|boolean|false|none|A value indicating whether the device is enabled on the platform.|
|supportLoRaFeatures|boolean|false|none|A value indicating whether the LoRa features is supported on this model.|
|statusUpdatedTime|string(date-time)|false|none|The device last status updated time.|

<h2 id="tocS_DeviceListItemPaginationResult">DeviceListItemPaginationResult</h2>
<!-- backwards compatibility -->
<a id="schemadevicelistitempaginationresult"></a>
<a id="schema_DeviceListItemPaginationResult"></a>
<a id="tocSdevicelistitempaginationresult"></a>
<a id="tocsdevicelistitempaginationresult"></a>

```json
{
  "items": [
    {
      "deviceID": "string",
      "deviceName": "string",
      "imageUrl": "string",
      "isConnected": true,
      "isEnabled": true,
      "supportLoRaFeatures": true,
      "statusUpdatedTime": "2019-08-24T14:15:22Z"
    }
  ],
  "totalItems": 0,
  "nextPage": "string"
}

```

Class representing the page results.

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|items|[[DeviceListItem](#schemadevicelistitem)]¦null|false|none|The current page items.|
|totalItems|integer(int32)|false|none|The total number of items.|
|nextPage|string¦null|false|none|The query next page Url.|

<h2 id="tocS_DeviceModel">DeviceModel</h2>
<!-- backwards compatibility -->
<a id="schemadevicemodel"></a>
<a id="schema_DeviceModel"></a>
<a id="tocSdevicemodel"></a>
<a id="tocsdevicemodel"></a>

```json
{
  "modelId": "string",
  "imageUrl": "string",
  "name": "string",
  "description": "string",
  "isBuiltin": true,
  "supportLoRaFeatures": true
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|modelId|string¦null|false|none|The device model identifier.|
|imageUrl|string¦null|false|none|The device model image Url.|
|name|string|true|none|The device model name.|
|description|string¦null|false|none|The device model description.|
|isBuiltin|boolean|false|none|A value indicating whether this instance is builtin.|
|supportLoRaFeatures|boolean|false|none|A value indicating whether the LoRa features is supported on this model.|

<h2 id="tocS_DeviceModelCommand">DeviceModelCommand</h2>
<!-- backwards compatibility -->
<a id="schemadevicemodelcommand"></a>
<a id="schema_DeviceModelCommand"></a>
<a id="tocSdevicemodelcommand"></a>
<a id="tocsdevicemodelcommand"></a>

```json
{
  "name": "string",
  "frame": "string",
  "port": 1,
  "isBuiltin": true
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|name|string|true|none|The command name.|
|frame|string|true|none|The command frame in hexa.|
|port|integer(int32)|true|none|The LoRa WAN port.|
|isBuiltin|boolean|false|none|A value indicating whether this instance is builtin.|

<h2 id="tocS_DeviceProperty">DeviceProperty</h2>
<!-- backwards compatibility -->
<a id="schemadeviceproperty"></a>
<a id="schema_DeviceProperty"></a>
<a id="tocSdeviceproperty"></a>
<a id="tocsdeviceproperty"></a>

```json
{
  "name": "string",
  "displayName": "string",
  "isWritable": true,
  "order": 0,
  "propertyType": "Boolean"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|name|string|true|none|The property name|
|displayName|string|true|none|The property display name|
|isWritable|boolean|true|none|Indicates whether the property is writable from the portal<br>> Note: if writable, the property is set to the desired properties of the device twin<br>>       otherwise, the property is read from the reported properties.|
|order|integer(int32)|true|none|The property display order.|
|propertyType|string|true|none|The device property type|

#### Enumerated Values

|Property|Value|
|---|---|
|propertyType|Boolean|
|propertyType|Double|
|propertyType|Float|
|propertyType|Integer|
|propertyType|Long|
|propertyType|String|

<h2 id="tocS_DevicePropertyValue">DevicePropertyValue</h2>
<!-- backwards compatibility -->
<a id="schemadevicepropertyvalue"></a>
<a id="schema_DevicePropertyValue"></a>
<a id="tocSdevicepropertyvalue"></a>
<a id="tocsdevicepropertyvalue"></a>

```json
{
  "name": "string",
  "displayName": "string",
  "isWritable": true,
  "order": 0,
  "propertyType": "Boolean",
  "value": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|name|string|true|none|The property name|
|displayName|string|true|none|The property display name|
|isWritable|boolean|true|none|Indicates whether the property is writable from the portal<br>> Note: if writable, the property is set to the desired properties of the device twin<br>>       otherwise, the property is read from the reported properties.|
|order|integer(int32)|true|none|The property display order.|
|propertyType|string|true|none|The device property type|
|value|string¦null|false|none|The current property value.|

#### Enumerated Values

|Property|Value|
|---|---|
|propertyType|Boolean|
|propertyType|Double|
|propertyType|Float|
|propertyType|Integer|
|propertyType|Long|
|propertyType|String|

<h2 id="tocS_DeviceTag">DeviceTag</h2>
<!-- backwards compatibility -->
<a id="schemadevicetag"></a>
<a id="schema_DeviceTag"></a>
<a id="tocSdevicetag"></a>
<a id="tocsdevicetag"></a>

```json
{
  "name": "string",
  "label": "string",
  "required": true,
  "searchable": true
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|name|string|true|none|The registered name in the device twin.|
|label|string|true|none|The label shown to the user.|
|required|boolean|false|none|Whether the field is required when creating a new device or not.|
|searchable|boolean|false|none|Whether the field can be searcheable via the device search panel or not.|

<h2 id="tocS_EnrollmentCredentials">EnrollmentCredentials</h2>
<!-- backwards compatibility -->
<a id="schemaenrollmentcredentials"></a>
<a id="schema_EnrollmentCredentials"></a>
<a id="tocSenrollmentcredentials"></a>
<a id="tocsenrollmentcredentials"></a>

```json
{
  "registrationID": "string",
  "symmetricKey": "string",
  "scopeID": "string",
  "provisioningEndpoint": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|registrationID|string¦null|false|none|none|
|symmetricKey|string¦null|false|none|none|
|scopeID|string¦null|false|none|none|
|provisioningEndpoint|string¦null|false|none|none|

<h2 id="tocS_IoTEdgeDevice">IoTEdgeDevice</h2>
<!-- backwards compatibility -->
<a id="schemaiotedgedevice"></a>
<a id="schema_IoTEdgeDevice"></a>
<a id="tocSiotedgedevice"></a>
<a id="tocsiotedgedevice"></a>

```json
{
  "deviceId": "string",
  "connectionState": "string",
  "scope": "string",
  "type": "string",
  "status": "string",
  "runtimeResponse": "string",
  "nbDevices": 0,
  "nbModules": 0,
  "environment": "string",
  "lastDeployment": {
    "name": "string",
    "dateCreation": "2019-08-24T14:15:22Z",
    "status": "string"
  },
  "modules": [
    {
      "moduleName": "string",
      "version": "string",
      "status": "string",
      "environmentVariables": {
        "property1": "string",
        "property2": "string"
      },
      "moduleIdentityTwinSettings": {
        "property1": "string",
        "property2": "string"
      }
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|deviceId|string|true|none|The IoT Edge identifier.|
|connectionState|string¦null|false|none|The IoT Edge connection state.|
|scope|string¦null|false|none|The IoT Edge scope tag value.|
|type|string|true|none|The IoT Edge device type.|
|status|string¦null|false|none|The IoT Edge device status.|
|runtimeResponse|string¦null|false|none|The IoT Edge runtime response.|
|nbDevices|integer(int32)|false|none|The number of connected devices on IoT Edge device.|
|nbModules|integer(int32)|false|none|The number of modules on IoT Edge device.|
|environment|string¦null|false|none|The IoT Edge environment tag value.|
|lastDeployment|[ConfigItem](#schemaconfigitem)|false|none|none|
|modules|[[IoTEdgeModule](#schemaiotedgemodule)]¦null|false|none|The IoT Edge modules.|

<h2 id="tocS_IoTEdgeListItem">IoTEdgeListItem</h2>
<!-- backwards compatibility -->
<a id="schemaiotedgelistitem"></a>
<a id="schema_IoTEdgeListItem"></a>
<a id="tocSiotedgelistitem"></a>
<a id="tocsiotedgelistitem"></a>

```json
{
  "deviceId": "string",
  "status": "string",
  "type": "string",
  "nbDevices": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|deviceId|string|true|none|The device identifier.|
|status|string¦null|false|none|The device status.|
|type|string¦null|false|none|The device type.|
|nbDevices|integer(int32)|false|none|The number of devices connected on the IoT Edge.|

<h2 id="tocS_IoTEdgeListItemPaginationResult">IoTEdgeListItemPaginationResult</h2>
<!-- backwards compatibility -->
<a id="schemaiotedgelistitempaginationresult"></a>
<a id="schema_IoTEdgeListItemPaginationResult"></a>
<a id="tocSiotedgelistitempaginationresult"></a>
<a id="tocsiotedgelistitempaginationresult"></a>

```json
{
  "items": [
    {
      "deviceId": "string",
      "status": "string",
      "type": "string",
      "nbDevices": 0
    }
  ],
  "totalItems": 0,
  "nextPage": "string"
}

```

Class representing the page results.

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|items|[[IoTEdgeListItem](#schemaiotedgelistitem)]¦null|false|none|The current page items.|
|totalItems|integer(int32)|false|none|The total number of items.|
|nextPage|string¦null|false|none|The query next page Url.|

<h2 id="tocS_IoTEdgeModule">IoTEdgeModule</h2>
<!-- backwards compatibility -->
<a id="schemaiotedgemodule"></a>
<a id="schema_IoTEdgeModule"></a>
<a id="tocSiotedgemodule"></a>
<a id="tocsiotedgemodule"></a>

```json
{
  "moduleName": "string",
  "version": "string",
  "status": "string",
  "environmentVariables": {
    "property1": "string",
    "property2": "string"
  },
  "moduleIdentityTwinSettings": {
    "property1": "string",
    "property2": "string"
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|moduleName|string|true|none|The module name.|
|version|string¦null|false|none|The module configuration version.|
|status|string¦null|false|none|The module status.|
|environmentVariables|object¦null|false|none|The module environment variables.|
|» **additionalProperties**|string¦null|false|none|none|
|moduleIdentityTwinSettings|object¦null|false|none|The module identity twin settings.|
|» **additionalProperties**|string¦null|false|none|none|

<h2 id="tocS_LoRaDeviceDetails">LoRaDeviceDetails</h2>
<!-- backwards compatibility -->
<a id="schemaloradevicedetails"></a>
<a id="schema_LoRaDeviceDetails"></a>
<a id="tocSloradevicedetails"></a>
<a id="tocsloradevicedetails"></a>

```json
{
  "deviceID": "string",
  "deviceName": "string",
  "modelId": "string",
  "imageUrl": "string",
  "isConnected": true,
  "isEnabled": true,
  "statusUpdatedTime": "2019-08-24T14:15:22Z",
  "tags": {
    "property1": "string",
    "property2": "string"
  },
  "classType": "A",
  "useOTAA": true,
  "appEUI": "string",
  "sensorDecoder": "string",
  "gatewayID": "string",
  "downlink": true,
  "preferredWindow": 0,
  "deduplication": "None",
  "rX1DROffset": 0,
  "rX2DataRate": 0,
  "rxDelay": 0,
  "abpRelaxMode": true,
  "fCntUpStart": 4294967295,
  "fCntDownStart": 4294967295,
  "supports32BitFCnt": true,
  "fCntResetCounter": 4294967295,
  "keepAliveTimeout": 0,
  "appKey": "string",
  "appSKey": "string",
  "nwkSKey": "string",
  "devAddr": "string",
  "alreadyLoggedInOnce": true,
  "dataRate": "string",
  "txPower": "string",
  "nbRep": "string",
  "reportedRX2DataRate": "string",
  "reportedRX1DROffset": "string",
  "reportedRXDelay": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|deviceID|string|true|none|The device identifier.|
|deviceName|string|true|none|The name of the device.|
|modelId|string|true|none|The model identifier.|
|imageUrl|string¦null|false|none|The device model image Url.|
|isConnected|boolean|false|none|`true` if this instance is connected; otherwise, `false`.|
|isEnabled|boolean|false|none|`true` if this instance is enabled; otherwise, `false`.|
|statusUpdatedTime|string(date-time)|false|none|The status updated time.|
|tags|object¦null|false|none|List of custom device tags and their values.|
|» **additionalProperties**|string¦null|false|none|none|
|classType|string|false|none|The LoRa device class.|
|useOTAA|boolean|false|none|The status of OTAA setting.|
|appEUI|string¦null|false|none|The device OTAA Application eui.|
|sensorDecoder|string¦null|false|none|The sensor decoder API Url.|
|gatewayID|string¦null|false|none|The GatewayID of the device.|
|downlink|boolean¦null|false|none|Allows disabling the downstream (cloud to device) for a device.<br>By default downstream messages are enabled.|
|preferredWindow|integer(int32)¦null|false|none|Allows setting the device preferred receive window (RX1 or RX2).<br>The default preferred receive window is 1.|
|deduplication|string|false|none|Allows controlling the handling of duplicate messages received by multiple gateways.<br>The default is None.|
|rX1DROffset|integer(int32)¦null|false|none|Allows setting an offset between received Datarate and retransmit datarate as specified in the LoRa Specifiations.<br>Valid for OTAA devices.<br>If an invalid value is provided the network server will use default value 0.|
|rX2DataRate|integer(int32)¦null|false|none|Allows setting a custom Datarate for second receive windows.<br>Valid for OTAA devices.<br>If an invalid value is provided the network server will use default value 0 (DR0).|
|rxDelay|integer(int32)¦null|false|none|Allows setting a custom wait time between receiving and transmission as specified in the specification.|
|abpRelaxMode|boolean¦null|false|none|Allows to disable the relax mode when using ABP.<br>By default relaxed mode is enabled.|
|fCntUpStart|integer(int32)¦null|false|none|Allows to explicitly specify a frame counter up start value.<br>If the device joins, this value will be used to validate the first frame and initialize the server state for the device.|
|fCntDownStart|integer(int32)¦null|false|none|Allows to explicitly specify a frame counter down start value.|
|supports32BitFCnt|boolean¦null|false|none|Allow the usage of 32bit counters on your device.|
|fCntResetCounter|integer(int32)¦null|false|none|Allows to reset the frame counters to the FCntUpStart/FCntDownStart values respectively.|
|keepAliveTimeout|integer(int32)¦null|false|none|Allows defining a sliding expiration to the connection between the leaf device and IoT/Edge Hub.<br>The default is none, which causes the connection to not be dropped.|
|appKey|string¦null|false|none|The OTAA App Key.|
|appSKey|string¦null|false|none|The APB AppSKey.|
|nwkSKey|string¦null|false|none|The APB NwkSKey.|
|devAddr|string¦null|false|none|Unique identifier that allows<br>the device to be recognized.|
|alreadyLoggedInOnce|boolean|false|none|A value indicating whether the device has already joined the platform.|
|dataRate|string¦null|false|none|The Device Current Datarate,<br>This value will be only reported if you are using Adaptive Data Rate.|
|txPower|string¦null|false|none|The Device Current Transmit Power,<br>This value will be only reported if you are using Adaptive Data Rate.|
|nbRep|string¦null|false|none|The Device Current repetition when transmitting.<br>E.g. if set to two, the device will transmit twice his upstream messages.<br>This value will be only reported if you are using Adaptive Data Rate.|
|reportedRX2DataRate|string¦null|false|none|The Device Current Rx2Datarate.|
|reportedRX1DROffset|string¦null|false|none|The Device Current RX1DROffset.|
|reportedRXDelay|string¦null|false|none|The Device Current RXDelay.|

#### Enumerated Values

|Property|Value|
|---|---|
|classType|A|
|classType|C|
|deduplication|None|
|deduplication|Drop|
|deduplication|Mark|

<h2 id="tocS_LoRaDeviceModel">LoRaDeviceModel</h2>
<!-- backwards compatibility -->
<a id="schemaloradevicemodel"></a>
<a id="schema_LoRaDeviceModel"></a>
<a id="tocSloradevicemodel"></a>
<a id="tocsloradevicemodel"></a>

```json
{
  "modelId": "string",
  "imageUrl": "string",
  "name": "string",
  "description": "string",
  "isBuiltin": true,
  "supportLoRaFeatures": true,
  "classType": "A",
  "useOTAA": true,
  "appEUI": "string",
  "sensorDecoder": "string",
  "downlink": true,
  "preferredWindow": 0,
  "deduplication": "None",
  "rX1DROffset": 0,
  "rX2DataRate": 0,
  "rxDelay": 0,
  "abpRelaxMode": true,
  "fCntUpStart": 4294967295,
  "fCntDownStart": 4294967295,
  "fCntResetCounter": 4294967295,
  "supports32BitFCnt": true,
  "keepAliveTimeout": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|modelId|string¦null|false|none|The device model identifier.|
|imageUrl|string¦null|false|none|The device model image Url.|
|name|string|true|none|The device model name.|
|description|string¦null|false|none|The device model description.|
|isBuiltin|boolean|false|none|A value indicating whether this instance is builtin.|
|supportLoRaFeatures|boolean|false|none|A value indicating whether the LoRa features is supported on this model.|
|classType|string|false|none|The LoRa device class.|
|useOTAA|boolean|false|none|The status of OTAA setting.|
|appEUI|string¦null|false|none|The device OTAA Application eui.|
|sensorDecoder|string¦null|false|none|The sensor decoder API Url.|
|downlink|boolean¦null|false|none|Allows disabling the downstream (cloud to device) for a device.<br>By default downstream messages are enabled.|
|preferredWindow|integer(int32)|false|none|Allows setting the device preferred receive window (RX1 or RX2).<br>The default preferred receive window is 1.|
|deduplication|string|false|none|Allows controlling the handling of duplicate messages received by multiple gateways.<br>The default is None.|
|rX1DROffset|integer(int32)¦null|false|none|Allows setting an offset between received Datarate and retransmit datarate as specified in the LoRa Specifiations.<br>Valid for OTAA devices.<br>If an invalid value is provided the network server will use default value 0.|
|rX2DataRate|integer(int32)¦null|false|none|Allows setting a custom Datarate for second receive windows.<br>Valid for OTAA devices.<br>If an invalid value is provided the network server will use default value 0 (DR0).|
|rxDelay|integer(int32)¦null|false|none|Allows setting a custom wait time between receiving and transmission as specified in the specification.|
|abpRelaxMode|boolean¦null|false|none|Allows to disable the relax mode when using ABP.<br>By default relaxed mode is enabled.|
|fCntUpStart|integer(int32)¦null|false|none|Allows to explicitly specify a frame counter up start value.<br>If the device joins, this value will be used to validate the first frame and initialize the server state for the device.|
|fCntDownStart|integer(int32)¦null|false|none|Allows to explicitly specify a frame counter down start value.|
|fCntResetCounter|integer(int32)¦null|false|none|Allows to reset the frame counters to the FCntUpStart/FCntDownStart values respectively.|
|supports32BitFCnt|boolean¦null|false|none|Allow the usage of 32bit counters on your device.|
|keepAliveTimeout|integer(int32)¦null|false|none|Allows defining a sliding expiration to the connection between the leaf device and IoT/Edge Hub.<br>The default is none, which causes the connection to not be dropped.|

#### Enumerated Values

|Property|Value|
|---|---|
|classType|A|
|classType|C|
|deduplication|None|
|deduplication|Drop|
|deduplication|Mark|

<h2 id="tocS_PortalSettings">PortalSettings</h2>
<!-- backwards compatibility -->
<a id="schemaportalsettings"></a>
<a id="schema_PortalSettings"></a>
<a id="tocSportalsettings"></a>
<a id="tocsportalsettings"></a>

```json
{
  "isLoRaSupported": true,
  "version": "string",
  "portalName": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|isLoRaSupported|boolean|false|none|A value indicating whether the LoRa features are acticated.|
|version|string¦null|false|none|The portal version.|
|portalName|string¦null|false|none|The poral name.|

<h2 id="tocS_ProblemDetails">ProblemDetails</h2>
<!-- backwards compatibility -->
<a id="schemaproblemdetails"></a>
<a id="schema_ProblemDetails"></a>
<a id="tocSproblemdetails"></a>
<a id="tocsproblemdetails"></a>

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|**additionalProperties**|any|false|none|none|
|type|string¦null|false|none|none|
|title|string¦null|false|none|none|
|status|integer(int32)¦null|false|none|none|
|detail|string¦null|false|none|none|
|instance|string¦null|false|none|none|

<h2 id="tocS_RouterConfig">RouterConfig</h2>
<!-- backwards compatibility -->
<a id="schemarouterconfig"></a>
<a id="schema_RouterConfig"></a>
<a id="tocSrouterconfig"></a>
<a id="tocsrouterconfig"></a>

```json
{
  "netID": [
    0
  ],
  "joinEui": [
    [
      "string"
    ]
  ],
  "region": "string",
  "hwspec": "string",
  "freqRange": [
    0
  ],
  "dRs": [
    [
      0
    ]
  ],
  "sx1301Conf": [
    {
      "property1": {
        "enable": true,
        "freq": 0,
        "radio": 0,
        "if": 0,
        "bandwidth": 0,
        "spreadFactor": 0
      },
      "property2": {
        "enable": true,
        "freq": 0,
        "radio": 0,
        "if": 0,
        "bandwidth": 0,
        "spreadFactor": 0
      }
    }
  ],
  "nocca": true,
  "nodc": true,
  "nodwell": true
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|netID|[integer]¦null|false|none|The network identifier.|
|joinEui|[array]¦null|false|none|The join eui.|
|region|string¦null|false|none|The region.|
|hwspec|string¦null|false|none|The hardware specifications.|
|freqRange|[integer]¦null|false|none|The frequency range.|
|dRs|[array]¦null|false|none|The DRs.|
|sx1301Conf|[object]¦null|false|none|The SX1301 conf.|
|» **additionalProperties**|[Channel](#schemachannel)|false|none|none|
|nocca|boolean|false|none|`true` if nocca; otherwise, `false`.|
|nodc|boolean|false|none|`true` if nodc; otherwise, `false`.|
|nodwell|boolean|false|none|`true` if nodwell; otherwise, `false`.|
