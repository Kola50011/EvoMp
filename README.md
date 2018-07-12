<h1 align="center">Evolution Multiplayer Framework</h1>

<div align="center">
  <strong>GT-MP fun and easy</strong>
</div>
<div align="center">
  A framework for creating sturdy Grand Theft Multiplayer Servers.
</div>

<br />

<p align="center">
  <a href="https://circleci.com/gh/Kola50011/EvoMp">
    <img src="https://circleci.com/gh/Kola50011/EvoMp/tree/master.svg?style=svg&circle-token=a08ea7263e55dcc44a56e10177951676b24b5243"
      alt="CircleCI">
  </a>
  <a href="https://www.gnu.org/licenses/lgpl-3.0">
    <img src="https://img.shields.io/badge/License-LGPL%20v3-blue.svg"
      alt="License: LGPL v3">
  </a>
</p>

<p align="center">
  <a href="https://evomp.de/">Website</a> •
  <a href="#key-features">Key Features</a> •
  <a href="#how-to-use">How To Use</a> •
  <a href="#credits">Credits</a> •
  <a href="#related">Related</a> •
  <a href="#license">License</a>
</p>

## Table of Contents

- [Table of Contents](#table-of-contents)
- [Key Features](#key-features)
- [How to Use (Windows)](#how-to-use-windows)
  - [1. Prerequisites](#1-prerequisites)
  - [2. Visual Studio Settings](#2-visual-studio-settings)
  - [3. Optional Visual Studio Settings](#3-optional-visual-studio-settings)
- [Credits](#credits)
- [Related](#related)
- [License](#license)
- [Debugging](#debugging)
  - [Entity Framework Query Debuging](#entity-framework-query-debuging)
- [Suggested IDE Addons / Plugins](#suggested-ide-addons--plugins)
  - [Visual Studio Code](#visual-studio-code)
- [Custom GT-MP type overwrites](#custom-gt-mp-type-overwrites)
- [Developing on Ubuntu](#developing-on-ubuntu)

## Key Features

* Server- & Clientside Modularisation
* Extensive Web-Framework Support
  * Preact
  * React
  * Vue.js
* import / export syntax on the client

## How to Use (Windows)

### 1. Prerequisites

In order to use this framework you need to clone and run everything. You'll need [Git](https://git-scm.com), [Visual Studio 2017](https://visualstudio.microsoft.com/), (& [Visual Studio Code](https://code.visualstudio.com/)), [Node.js 8.x.x](https://nodejs.org/) & [Yarn](https://yarnpkg.com/)

```bash
# Clone this repository
$ git clone https://github.com/Kola50011/EvoMp.git

# Go into the repository
$ cd EvoMp

# Install clientside dependencies
$ yarn install
```

### 2. Visual Studio Settings

- Open <code>EvoMp/EvoMp.sln</code>
- Right click on project <code>EvoMp.Core.StartupProject</code>
- Choose <code>Debugging</code>
- As an external programm enter the path <code>....../GTMP_Server/*server.exe</code>
- As workspace select  <code>....../GTMP_Server/</code>
- Right click on the project solution and select <code>rebuild all</code>
- Finally press <code>Run</code>

### 3. Optional Visual Studio Settings

- Tools / Extras -> Options
  - Go to <code>Projects and Solutions</code>
  - Select subitem <code>Build and Run</code>
  - Under <code>On Run, when projects are out of date</code> select <code>Always build</code>
  - Uncheck <code>Only build startup projects and dependencies on Run</code>

## Credits

This framework makes use of several open source project. For details [see here](https://github.com/Kola50011/EvoMp/network/dependencies).

- [Node.js](https://nodejs.org/)
- [Parcel-Bundler](https://github.com/parcel-bundler/parcel)
- [TypeScript](https://github.com/Microsoft/TypeScript)
- [Webpack](https://github.com/webpack/webpack)
- ...

This README.md file is based upon the work of [electron-markdownify](https://github.com/amitmerchant1990/electron-markdownify)

## Related

- [Grand Theft Multiplayer](https://gt-mp.net/)

## License

This framework is licensed under the GNU LGPLv3. See [LICENSE](https://github.com/Kola50011/EvoMp/blob/master/LICENSE) for details.

## Debugging

### Entity Framework Query Debuging

Add the following line in the context constructor to enable the logging:

```csharp
Database.Log = s => { };
```

Full Example:
```csharp
public VehicleContext() : base(Environment.GetEnvironmentVariable("NameOrConnectionString"))
{
    // Database logging
    Database.Log = s => { };
}
```

## Suggested IDE Addons / Plugins

### Visual Studio Code

- [Prettier - Code Formatter (JavaScript Files)](https://marketplace.visualstudio.com/items?itemName=esbenp.prettier-vscode)
- [TSLint](https://marketplace.visualstudio.com/items?itemName=eg2.tslint)


## Custom GT-MP type overwrites
- __Any custom type begins with the prefix "Extended"__
  - VehicleHandler ~ ExtendedVehicle
  - ...


## Developing on Ubuntu

```bash
# Run the following commands as a su
$ sudo -s

# Set variables for setup
$ MyGetUserName=USERNAME; # For MyGet access
$ MyGetPassword=PASSWORD; # For MyGet access
$ MyGetApiKey=MYGETAPIKEY; # For MyGet access (Can be generated on the MyGet site)
$ RepositoryRoot='/path/to/EvoMp'; # Your RepositoryRoot path

# Install Mono
$ apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
$ echo "deb http://download.mono-project.com/repo/ubuntu xenial main" | tee /etc/apt/sources.list.d/mono-official.list
$ apt-get install mono-devel -y

# Install NuGet
$ apt-get update
$ apt-get install nuget -y

# (OPTIONAL) Set MyGet source as the NuGet source
$ nuget setapikey $MyGetApiKey -source "https://www.myget.org/F/gt5mp/api/v2"
$ nuget sources add -Name "grandtheftmultiplayer.api" -source "https://www.myget.org/F/gt5mp/api/v2" -User $MyGetUserName -pass $MyGetPassword -ConfigFile ~/.config/NuGet/NuGet.Config

# NuGet restore
$ cd $RepositoryRoot/EvoMp
$ nuget restore EvoMp.sln -NoCache -ConfigFile ~/.config/NuGet/NuGet.Config

# Compile the Server-Side
$ msbuild EvoMp.sln /p:TargetFrameworkVersion=v4.6.2 /p:Configuration=Linux EvoMp.sln

# Install NodeJS
$ curl -sL https://deb.nodesource.com/setup_8.x | bash -
apt-get install -y nodejs

# Install Yarn
$ apt-get install apt-transport-https -y
$ curl -sS https://dl.yarnpkg.com/debian/pubkey.gpg | apt-key add -""
$ echo "deb https://dl.yarnpkg.com/debian/ stable main" | tee /etc/apt/sources.list.d/yarn.list
$ apt-get update && apt-get install yarn -y

# Get Clientside Dependencies
$ cd $RepositoryRoot
$ yarn install

# Compile the Client-Side
$ yarn build

# Start the server
$ cd $RepositoryRoot/GTMP_Server
$ mono GrandTheftMultiplayer.Server.exe
```
