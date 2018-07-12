const Bundler = require("parcel-bundler");
const Glob = require("glob");

async function main() {
  const files = Glob.sync("EvoMp/*/Web/*.+(html|pug)");
  const prod = process.env.NODE_ENV === 'production';

  const options = {
    outDir: "GTMP_Server/resources/EvoMp/dist",
    sourceMaps: false,
    minify: prod,
    logLevel: 3,
    detailedReport: true
  }

  console.log('\n[EvoMP Web-Compiler] Started')
  console.log(`[EvoMP Web-Compiler] Build: ${prod ? 'Production' : 'Development'}\n`)

  if (!prod) {
    const promises = files.map(async (file) => {
      const bundler = new Bundler(file, options);
      return bundler.bundle();
    })
  
    await Promise.all(promises)  
  } else {
    for (let file of files) {
      const bundler = new Bundler(file, options);
      await bundler.bundle();
    }
  }

  const date = new Date();
  console.log(
    console.log('\n[EvoMP Web-Compiler] Finished\n')
  );

  process.exit(0)
}

main();
