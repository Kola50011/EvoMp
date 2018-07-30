const Bundler = require("parcel-bundler");
const Glob = require("glob");

async function main() {
  const prod = process.env.NODE_ENV === 'production';

  const options = {
    outDir: "GTMP_Server/resources/EvoMp/dist",
    sourceMaps: false,
    minify: prod,
    logLevel: 3,
    detailedReport: true,
    publicUrl: "/dist/"
  }

  console.log('\n[EvoMP Web-Compiler] Started')
  console.log(`[EvoMP Web-Compiler] Build: ${prod ? 'Production' : 'Development'}\n`)

  const bundler = new Bundler('EvoMp/*/Web/*.+(html|pug)', options);
  await bundler.bundle();

  console.log('\n[EvoMP Web-Compiler] Finished\n')

  process.exit(0)
}

main();
