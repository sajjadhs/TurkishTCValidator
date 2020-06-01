# TurkishTCValidator
Turkish People Identity Number Online and Offline Validator in .Net

You can validate online and over api's, or validate offline. 

Easily can validate Native and Foreigners ID number

<b>
Usage for online validation:
</b>

```csharp
TC_Online_Validator _Validator = new  TC_Online_Validator();
var result = _Validator.ValidateForeigner(99999999999, "NAME", "LASTNAME", 1992, 01, 01);
```

<b>
Usage for offline validation:
</b>

 ```csharp
TC_Offline_Validator _Validator = new TC_Offline_Validator();
var result = _Validator.Validate(99999999999);
```


Just clone the project, and Build and add .dll file to your project :)
