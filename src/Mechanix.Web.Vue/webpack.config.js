var path = require('path')
var webpack = require('webpack')
var CopyWebpackPlugin = require('copy-webpack-plugin')

module.exports = {
  entry: ['./app/main.js','./app/common.js'],
  output: {
    path: path.resolve(__dirname, './dist'),
    publicPath: '/',
    filename: 'app.bundle.js'
  },
  resolveLoader: {
    root: path.join(__dirname, 'node_modules')
  },
  module: {
    loaders: [
    ]
  },
  devServer: {
    historyApiFallback: true,
    noInfo: true,
    proxy: {
      '/oauth2/*': {
        target: 'http://localhost:59911/',
        secure: false
      },
      '/api': {
        target: 'http://localhost:59911/',
        secure: false
      },
    }
  },
  devtool: '#eval-source-map',
  plugins: [
      new CopyWebpackPlugin([
          { from: 'lib', to: 'lib' }
      ])
  ]
}