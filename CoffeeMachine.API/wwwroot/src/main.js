import Vue from 'vue';
import App from './App.vue';
import VueRouter from 'vue-router';
import vuetify from '@/plugins/vuetify';
import router from './router';
import store from '@/store/index';
import { VueMaskDirective } from 'v-mask'
import VueApexCharts from 'vue-apexcharts'

Vue.config.productionTip = false
Vue.use(VueRouter)
Vue.directive('mask', VueMaskDirective);
Vue.use(VueApexCharts)
Vue.use(require('vue-moment'));
Vue.component('apexchart', VueApexCharts)
import "@/assets/global.css"


new Vue({
  router,
  vuetify,
  store,
  render: h => h(App)
}).$mount('#app');