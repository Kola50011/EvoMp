const glob = require('glob')
const path = require('path')
const webpack = require('webpack')
const UglifyJSPlugin = require('uglifyjs-webpack-plugin')
const { CheckerPlugin } = require('awesome-typescript-loader')

var files = glob.sync('./EvoMp/*/Client/*.ts')

module.exports = {
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
  resolve: {
    extensions: ['.ts']
  },
  plugins: [
    new webpack.DefinePlugin({
      'process.env': {
        'NODE_ENV': JSON.stringify('production')
      }
    }),
    new UglifyJSPlugin(),
    new CheckerPlugin(),
    new webpack.BannerPlugin(require('fs').readFileSync('LICENSE', 'utf8'))
  ]
}
