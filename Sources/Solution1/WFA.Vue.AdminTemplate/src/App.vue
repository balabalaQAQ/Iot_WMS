<template>
  <!-- 主要是构建 SPA (单页应用) 时，方便渲染指定路由对应的组件 -->
  <!-- 这里的路由配置由 .router/index.js 约束 -->
  <router-view></router-view>
</template>

<script>
  export default {
    name: 'app'
  }
</script>

<style lang="scss">
  /* 导入 CoreUI 图标库 */
  @import '~@coreui/icons/css/coreui-icons.min.css';

  /* 导入 Font Awesome 图标库 */
  $fa-font-path: '~font-awesome/fonts/';
  @import '~font-awesome/scss/font-awesome.scss';

  /* 导入线形图标库 */
  $simple-line-font-path: '~simple-line-icons/fonts/';
  @import '~simple-line-icons/scss/simple-line-icons.scss';

  /* 导入旗帜图标库 */
  @import '~flag-icon-css/css/flag-icon.min.css';

  /* 导入 Bootstrap Vue 样式 */
  @import '~bootstrap-vue/dist/bootstrap-vue.css';

  /* 导入内置的样式表 */
  @import 'assets/scss/style';
</style>
