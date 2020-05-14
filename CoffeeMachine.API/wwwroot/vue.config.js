module.exports = {

  "transpileDependencies": [
    "vuetify"
    ],
    devServer: {
        proxy: 'https://localhost:44394/',
    },
  publicPath: process.env.NODE_ENV === 'production'
  ? '/' + process.env.CI_PROJECT_NAME + '/'
  : '/'
}