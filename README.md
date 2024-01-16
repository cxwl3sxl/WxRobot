## send message via web api
post /api/wx/SendMessage
```
{
    "to": "the firend name",
    "message": "the message"
}
```

response:
```
{
    "ReturnCode": 200.0,
    "Message": "OK",
    "Body": "the id of message, can check send result via this code"
}
```

## check message send status via web api
get /api/wx/CheckResult?idMsg=xxx

response:
```
{
    "ReturnCode": 200.0,
    "Message": "OK",
    "Body": {
        "IdMsg": "43f62ba0-e2c3-4ddd-a221-bd16a0281e1f",
        "To": "the source firend name",
        "Msg": "the source message content",
        "IsSend": true,
        "Result": "",
        "CreateByName": "System",
        "CreateAt": "2024-01-16 09:58:23.535",
        "CreateId": "00000000-0000-0000-0000-000000000000",
        "LastUpdateByName": "System",
        "LastUpdateAt": "2024-01-16 09:58:30.574",
        "LastUpdateId": "00000000-0000-0000-0000-000000000000"
    }
}
```
