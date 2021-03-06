const webpack = require("webpack");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const ExtractTextPlugin = require("extract-text-webpack-plugin");
const CopyWebpackPlugin = require("copy-webpack-plugin");
const cleanWebpackPlugin = require("clean-webpack-plugin");
const UglifyJsParallelPlugin = require("webpack-uglify-parallel");
const merge = require("webpack-merge");
const webpackBaseConfig = require("./webpack.base.config.js");
const os = require("os");
const fs = require("fs");
const path = require("path");
const package = require("../package.json");

fs.open("./build/env.js", "w", function(err, fd) {
  const buf = 'export default "production";';
  fs.write(fd, buf, 0, buf.length, 0, function(err, written, buffer) {});
});

module.exports = merge(webpackBaseConfig, {
  output: {
    publicPath: "/dist/", // 修改 https://iv...admin 这部分为你的服务器域名
    filename: "[name].[hash].js",
    chunkFilename: "[name].[hash].chunk.js"
  },
  plugins: [
    new cleanWebpackPlugin(["dist/*"], {
      root: path.resolve(__dirname, "../")
    }),
    new ExtractTextPlugin({
      filename: "[name].[hash].css",
      allChunks: true
    }),
    new webpack.optimize.CommonsChunkPlugin({
      // name: 'vendors',
      // filename: 'vendors.[hash].js'
      name: ["vender-exten", "vender-base"],
      minChunks: Infinity
    }),

    new webpack.DefinePlugin({
      "process.env": {
        NODE_ENV: '"production"'
      }
    }),
    new webpack.optimize.UglifyJsPlugin({
      compress: {
        warnings: false
      }
    }),
    new CopyWebpackPlugin(
      [
        {
          from: "abp.ico"
        },
        {
          from: "src/styles/fonts",
          to: "fonts"
        },
        {
          from: "src/views/main-components/theme-switch/theme"
        },
        {
          from: "node_modules/abp-web-resources/Abp/Framework/scripts/abp.js",
          to: "abp"
        },
        {
          from: "node_modules/jquery/dist/jquery.min.js"
        },
        {
          from:
            "node_modules/abp-web-resources/Abp/Framework/scripts/libs/abp.jquery.js",
          to: "abp"
        }
      ],
      {
        ignore: ["text-editor.vue"]
      }
    ),
    new HtmlWebpackPlugin({
      title: "School v" + package.version,
      favicon: "./abp.ico",
      filename: "../index.html",
      template: "!!ejs-loader!./src/template/index.ejs",
      inject: false
    })
  ]
});
