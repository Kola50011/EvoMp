const glob = require('glob');
const path = require('path');
const webpack = require('webpack');
const HardSourceWebpackPlugin = require('hard-source-webpack-plugin');

const files = glob.sync('./EvoMp/*/Client/*.ts');

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
    rules: [
      {
        test: /\.ts/,
        loader: 'awesome-typescript-loader?configFileName=./tsconfig.json'
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
    new webpack.BannerPlugin(require('fs').readFileSync('LICENSE', 'utf8'))
  ]
};
