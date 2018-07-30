const Glob = require("glob");
const fs = require("fs");

async function cleanDist() {
  const files = Glob.sync("GTMP_Server/resources/EvoMp/dist/*.+(html|js|css|woff2)");
  const promises = files.map(file => {
    return new Promise((resolve, reject) => {
      fs.unlink(file, err => {
        if (err) {
          reject(err)
        } else {
          resolve()
        }
      })
    })
  })

  await Promise.all(promises)

  console.log("[EvoMP Cleanup] Dist cleared")
}

cleanDist();
