# Style-Sharp

An open source CSS parser for C# applications

![Build status](https://ci.appveyor.com/api/projects/status/1s8wus8xse72c2e9?svg=true)

## Our goal

StyleSharp tries to provide a universal stylesheet parser. It does not conform with the CSS standards, but instead lets you register your own datatypes and properties to make it as adaptive as possible to your needs as a software developer.

### TL;DR
StyleSharp allowes flexible styling of your C# application.

## Example

Consider you have a button in your application and you want it to be moddable for 3rd party users. Your button is derived by a `CustomControl` and implements `StyleSharp.Styleable` and overrides the `OnRender` function. On startup (or whenever it is needed) load the stylesheet
```C#
var s = StyleSharp.StyleSheet.Parse("styles.css");
```

Build a DOM tree
```C#
var dom = new StyleSharp.DOMTree();
dom.RootElem = new Button("Click me");
```

and apply the stylesheet
```C#
dom.ApplyStyles(s);
```

Your button then gets its styles assigned automatically. If it is the child of `Pane` with id `mypane1` then the following style
```CSS
#mypane1 Button {
  background: red;
}
```

will be applied to your button, but the following style
```CSS
#mypane2 Button {
  background: green;
}
```

will not.
