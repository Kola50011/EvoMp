const xmlbuilder = require("xmlbuilder");
const Glob = require("glob");
const fs = require("fs");

function writeXml() {
  console.log("\n[EvoMP Meta.xml Generator] Started");

  const files = Glob.sync("GTMP_Server/resources/EvoMp/dist/**/*.+(js|css|html)");
  let root = xmlbuilder.create("meta");
  let infoElem = root.element("info");
  infoElem.attribute("name", "Evolution Multiplayer");
  infoElem.attribute("author",
    "Koka, Ruffo (Christian Groothoff), Sascha <sascha@localhost.systems>, Lukas, DevGrab, James");
  infoElem.attribute("version", "1.0.0");
  infoElem.attribute("shadowcopy", true);

  let serversideSrc = root.element("script");
  serversideSrc.attribute("lang", "compiled");
  serversideSrc.attribute("src", "dist/EvoMp.Core.Core.dll");
  serversideSrc.attribute("type", "server");

  let clientsideSrc = root.element("script");
  clientsideSrc.attribute("javascript", "compiled");
  clientsideSrc.attribute("src", "dist/main.bundle.js");
  clientsideSrc.attribute("type", "client");

  for (const file of files) {
    if (file.endsWith("main.bundle.js")) {
      continue;
    }
    let fileElem = root.element("file");
    fileElem.attribute("src", file.replace("GTMP_Server/resources/EvoMp/", ""));
  }

  const xml = root.end({ pretty: true });
  fs.writeFileSync("GTMP_Server/resources/EvoMp/meta.xml", xml);
  console.log("[EvoMP Meta.xml Generator] Finished\n");
}

writeXml();
