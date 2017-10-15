# Setup project solution guide  
## Required settings  
- Open "EvoMp/EvoMp.sln".  
- Right click on project "EvoMp.Core.StartupProject".  
  Go to "Debuggen/Debugging"  
  Select under "External programm / Externes Programm starten" the path > "....../GTMP_Server/*server.exe"  
  and under "Workspace / Arbeitsverzeichniss" > "....../GTMP_Server/  "

  -> Ruffo: Really sorry, that this couldn't done with placeholder like $(ProjectDir). But placeholder can't used there.. :<  

- Right click on "Project Solution / Projektmappe", click "rebuild all / Alles neu erstellen".  
- Click on Start.  


## Optimal settings  
- "Tools/Extras" -> "Options / Optionen"  
  -> Go to "Projects and Solutions / Projekte und Projektmappen" Erstellen    
  -> Select subitem "Build and Run / Erstellen und Ausführen"    
  -> Select on "On Run, when projects are out of date / Beim Ausführen, bei nicht aktuellen Projekten", "Always build / Immer erstellen"  