Softbuild.Security.PasswordStrength
===================================
`Softbuild.Security.PasswordStrength` is a simple validator for checking password strength. original project is [PWStrength](https://github.com/laiso/PWStrength).

![alt text](http://cdn-ak.f.st-hatena.com/images/fotolife/c/ch3cooh393/20140108/20140108122829.gif)

```cs
var result = Softbuild.Security.PasswordStrength.Validate("simple");
result.Complexity; // 0.0f - 1.0f
result.Valid; // YES or NO
```

License
===================================
MIT
