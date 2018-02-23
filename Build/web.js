const Bundler = require('parcel-bundler')
const Glob = require('glob')

async function main () {
  let files = Glob.sync('EvoMp/*/Web/*.+(html|pug)')

  for (const file of files) {
    process.env.NODE_ENV = 'production'
    await new Bundler(file, {outDir: 'GTMP_Server/resources/EvoMp/dist'}).bundle()
  }
}

main()
