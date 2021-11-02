module.exports = {
  lintOnSave: false,
  runtimeCompiler: true,
  publicPath: '/',
  devServer:{
    proxy:
    {
      '/api':
      {
        target:"http://localhost:5001/",
        changeOrigin:true,
        ws:false,
        pathRewrite:
        {
          '/api/':''

        }
      }

    }

  }
}
