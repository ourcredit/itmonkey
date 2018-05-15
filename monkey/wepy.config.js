const path = require("path")
var prod = process.env.NODE_ENV === "production"
module.exports = {
  eslint: false,
  wpyExt: ".wpy",
  resolve: {
    alias: {
      "@": path.join(__dirname, "src"),
      "api": path.join(__dirname, "src/api"),
      "tools": path.join(__dirname, "src/utils")
    },
    aliasFields: ["wepy"],
    modules: ["node_modules"]
  },
  compilers: {
    less: {
      compress: prod
    },
    sass: {
      outputStyle: "compressed"
    },
    babel: {
      sourceMap: true,
      presets: ["es2015", "stage-1"],
      plugins: ["transform-export-extensions", "syntax-export-extensions", "transform-decorators-legacy"]
    }
  }
}
