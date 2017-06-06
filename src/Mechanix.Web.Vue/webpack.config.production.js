var path = require('path')
var webpack = require('webpack')
var CopyWebpackPlugin = require('copy-webpack-plugin')

module.exports = {
  entry: ['./app/main.js','./app/common.js'],
  output: {
    path: path.resolve(__dirname, '../Mechanix.Web/dist'),
    publicPath: '../Mechanix.Web/dist/',
    filename: 'app.bundle.js'
  },
  resolveLoader: {
    root: path.join(__dirname, 'node_modules')
  },
  module: {
    loaders: [
      {
        test: /\.vue$/,
        loader: 'vue'
      },
      {
        test: /\.js$/,
        loader: 'babel',
        exclude: /node_modules/
      },
      {
        test: /\.json$/,
        loader: 'json'
      },
      {
        test: /\.html$/,
        loader: 'vue-html'
      },
      {
        test: /\.(png|jpg|gif|svg)$/,
        loader: 'url',
        query: {
          limit: 10000,
          name: '[name].[ext]?[hash]'
        }
      }
    ]
  },
  plugins: [
      new CopyWebpackPlugin([
          { from: 'lib', to: 'lib' },
          { from: 'app/i', to: 'i' },
          { from: 'app/css', to: 'css' }
      ])
  ]
}

module.exports.plugins = (module.exports.plugins || []).concat([
new webpack.DefinePlugin({
    'process.env': {
    NODE_ENV: '"production"'
    }
}),
new webpack.optimize.UglifyJsPlugin({
    compress: {
    warnings: false
    }
}),
new webpack.optimize.OccurenceOrderPlugin()
])
