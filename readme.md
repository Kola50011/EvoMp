# Setup project solution guide

## Required Software
- Visual Studio > 2017
- NodeJs > 8.X
- Yarn

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


# Run on Ubuntu
Run the following commands
## Step 1 - Set variables
```bash
sudo -s
# Set variables for setup
MyGetUserName=USERNAME; # For MyGet acess
MyGetPassword=PASSWORD; # For MyGet acess
MyGetApiKey=MYGETAPIKEY; # For MyGet acess (Muste be generated on the MyGet site)
RepositoryRoot='/mnt/c/!_Files/1_Programming/3_GitHub/EvoMpCore'; # Your RepositoryRoot path
```
## Step 2 - Install mono
```bash
cd "$RepositoryRoot";
## Server Side
# Mono
apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
echo "deb http://download.mono-project.com/repo/ubuntu xenial main" | tee /etc/apt/sources.list.d/mono-official.list
apt-get install mono-devel -y
```
## Step 3 - Install NuGet
```bash
# NuGet setup
apt-get update
apt-get install nuget -y
```
## Step 4 - Set MyGet source
```bash
nuget setapikey $MyGetApiKey -source "https://www.myget.org/F/gt5mp/api/v2"
nuget sources add -Name "grandtheftmultiplayer.api" -source "https://www.myget.org/F/gt5mp/api/v2" -User $MyGetUserName -pass $MyGetPassword -ConfigFile ~/.config/NuGet/NuGet.Config
```
## Step 5 - Restore NuGet and build Server
```bash
# NuGet restore & Server build
cd EvoMp
nuget restore EvoMp.sln -NoCache -ConfigFile ~/.config/NuGet/NuGet.Config

msbuild EvoMp.sln /p:TargetFrameworkVersion=v4.6.2 /p:Configuration=Linux EvoMp.sln
```
## Step 6 - Install nodeJs
```bash
## Client Side
# NodeJs
curl -sL https://deb.nodesource.com/setup_8.x | bash -
apt-get install -y nodejs
```

## Step 7 - Install Yarn
```bash
# Yarn
apt-get install apt-transport-https -y
curl -sS https://dl.yarnpkg.com/debian/pubkey.gpg | apt-key add -""
echo "deb https://dl.yarnpkg.com/debian/ stable main" | tee /etc/apt/sources.list.d/yarn.list
apt-get update && apt-get install yarn
```

## Step 8 - Compile client side
```bash
# Client side compile
cd "$RepositoryRoot"
yarn install
yarn build
```

## Step 9 - Start Server (Currently in progress) 
```bash
## Start Server
#cd GTMP_Server;
#mono GrandTheftMultiplayer.Server.exe;
```