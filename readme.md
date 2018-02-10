# Setup project solution guide

## Required Software
- Visual Studio > 2017
- NodeJs > 8.X
- 

## Required settings
- Open "EvoMp/EvoMp.sln".
- Right click on project "EvoMp.Core.StartupProject".
  Go to "Debuggen/Debugging"
  Select under "External programm / Externes Programm starten" the path "....../GTMP_Server/*server.exe"
  and under "Workspace / Arbeitsverzeichniss" ....../GTMP_Server/

  -> Ruffo: Really sorry, that this couldn't done with placeholder like $(ProjectDir). But placeholder can't used there.. :<

- Right click on "Project Solution / Projektmappe", click "rebuild all / Alles neu erstellen".
- Click on Start.

### Clientside
- Open CMD and go to root directory
- Run command "yarn install"
- Run "yarn build"

## Optimal settings

- "Tools/Extras" -> "Options / Optionen"
  -> Go to "Projects and Solutions / Projekte und Projektmappen" Erstellen
  -> Select subitem "Build and Run / Erstellen und Ausführen"
  -> Select on "On Run, when projects are out of date / Beim Ausführen, bei nicht aktuellen Projekten", "Always build / Immer erstellen"
  -> Also uncheck "only build startup projects and dependencies on Run / Nur Startprojekte und Abhängigkeiten zur Laufzeit ausführen"

## Usefull hints for developing

- Don't use Database Entitys from other modules as Type.
  (Ask Ruffo if interested why..)

### Debug tips
#### Entity Framework query debug
Add the following line in the context constructor to enable the logging:
```CSharp
Database.Log = s => { };
```

Full Example:
```CSharp
public VehicleContext() : base(Environment.GetEnvironmentVariable("NameOrConnectionString"))
{
    // Database logging
    Database.Log = s => { };
}
```

## Suggested IDE Addons / Plugins

### Visual Studio Code

- [Prettier-Standard Code Formatter (JavaScript Files)](https://marketplace.visualstudio.com/items?itemName=iSayme.vscode-prettier-standard)
- [Prettier-Standard Code Formatter (TypeScript Files)](https://marketplace.visualstudio.com/items?itemName=esbenp.prettier-vscode)
- [Typescript Linter TSLint](https://marketplace.visualstudio.com/items?itemName=eg2.tslint)


## Custom GT-MP type overwrites
- __Any custom type begins with the prefix "Extended"__
  -> VehicleHandler ~ ExtendedVehicle
  -> ...
