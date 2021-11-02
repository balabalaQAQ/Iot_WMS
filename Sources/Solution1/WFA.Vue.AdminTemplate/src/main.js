// 导入框架所需要的内置js数据
import 'core-js/es6/promise'
import 'core-js/es6/string'
import 'core-js/es7/array'

// 导入 Vue 插件包
import Vue from 'vue'
import BootstrapVue from 'bootstrap-vue'
import App from './App'
import router from './router'
import oidc from '../oidc'
import axios from '../axios'

Vue.prototype.$oidc=oidc
Vue.prototype.$axios=axios

// 使用 BootstrapVue 插件
Vue.use(BootstrapVue)

// 初始化 App.vue
new Vue({
  el: '#app',
  router,
  template: '<App/>',
  components: {
    App
  }
})
