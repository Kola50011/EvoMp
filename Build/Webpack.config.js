const glob = require('glob')
const path = require('path')
const webpack = require('webpack')
const UglifyJSPlugin = require('uglifyjs-webpack-plugin')
const HardSourceWebpackPlugin = require('hard-source-webpack-plugin')
const { CheckerPlugin } = require('awesome-typescript-loader')
const TSLintPlugin = require('tslint-webpack-plugin')

var files = glob.sync('./EvoMp/*/Client/*.ts')

module.exports = {
  context: path.resolve(__dirname, '../'),
  entry: {
    main: files
  },
  output: {
    path: path.resolve(__dirname, '../GTMP_Server/resources/EvoMp/dist'),
    filename: 'main.bundle.js'
  },
  module: {
    loaders: [
      {
        test: /\.ts/,
        loader: 'awesome-typescript-loader?configFileName=tsconfig.json'
      }
    ]
  },
  performance: {
    hints: 'warning'
  },
  stats: {
    all: false,
    assets: true,
    cached: true,
    cachedAssets: true,
    colors: true,
    env: true,
    errors: true,
    warnings: true,
    assetsSort: 'field'
  },
  resolve: {
    extensions: ['.ts']
  },
  plugins: [
    new HardSourceWebpackPlugin({
      cacheDirectory: '../../../../.cache'
    }),
    new TSLintPlugin({
      files: files,
      typeCheck: true,
      project: 'tsconfig.json'
    }),
    new CheckerPlugin(),
    new UglifyJSPlugin(),
    new webpack.BannerPlugin(require('fs').readFileSync('LICENSE', 'utf8'))
  ]
}
