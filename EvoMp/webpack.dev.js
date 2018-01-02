const glob = require('glob')
const path = require('path')
const webpack = require('webpack')

var files = glob.sync('./*.Module.*/Client/*.ts')

module.exports = {
  entry: {
    main: files
  },
  output: {
    path: path.resolve(__dirname, './dist'),
    filename: 'main.bundle.js'
  },
  module: {
    loaders: [
      {
        test: /\.ts/,
        loader: 'awesome-typescript-loader?configFileName=tsconfig-dev.json'
      }
    ]
  },
  resolve: {
    extensions: ['.ts']
  },
  plugins: [
    new webpack.DefinePlugin({
      'process.env': {
        'NODE_ENV': JSON.stringify('development')
      }
    })
  ]
}
