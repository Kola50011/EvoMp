const Bundler = require('parcel-bundler')
const Glob = require('Glob')

async function main () {
  let files = Glob.sync('EvoMp/*/Web/*.+(html|pug)')

  for (const file of files) {
    await new Bundler(file, {outDir: 'GTMP_Server/resources/EvoMp/dist'}).bundle()
  }
}

main()
