<template>
  <div class="app">
    <!-- 页头 -->
    <AppHeader fixed>
      <SidebarToggler class="d-lg-none" display="md" mobile />
      <b-link class="navbar-brand" to="#">
        <img class="navbar-brand-full" src="img/brand/logo.svg" width="89" height="25" alt="CoreUI Logo">
        <img class="navbar-brand-minimized" src="img/brand/sygnet.svg" width="30" height="30" alt="CoreUI Logo">
      </b-link>
      <SidebarToggler class="d-md-down-none" display="lg" :defaultOpen=true />
      <b-navbar-nav class="d-md-down-none">
        <b-nav-item class="px-3" to="/dashboard">数字仪表盘</b-nav-item>
        <b-nav-item class="px-3" to="/users" exact>用户信息</b-nav-item>
        <b-nav-item class="px-3">系统设置</b-nav-item>
      </b-navbar-nav>
      <b-navbar-nav class="ml-auto">
        <b-nav-item class="d-md-down-none">
          <i class="icon-bell"></i>
          <b-badge pill variant="danger">5</b-badge>
        </b-nav-item>
        <b-nav-item class="d-md-down-none">
          <i class="icon-list"></i>
        </b-nav-item>
        <b-nav-item class="d-md-down-none">
          <i class="icon-location-pin"></i>
        </b-nav-item>
        <!-- 头像和下拉菜单组件 -->
        <DefaultHeaderDropdownAccnt/>
      </b-navbar-nav>
      <AsideToggler class="d-none d-lg-block" />
      <!--<AsideToggler class="d-lg-none" mobile />-->
    </AppHeader>

    <!-- 应用工作区 -->
    <div class="app-body">
      <!-- 侧边栏导航菜单 -->
      <AppSidebar fixed>
        <SidebarHeader />
        <SidebarForm />
        <!-- 侧边栏菜单导航树，绑定的数据 nav -->
        <SidebarNav :navItems="nav"></SidebarNav>
        <SidebarFooter />
        <SidebarMinimizer />
      </AppSidebar>
      <!-- 主工作区 -->
      <main class="main">
        <!-- 页面导航指示 -->
        <Breadcrumb :list="list"/>
        <div class="container-fluid">
          <!-- 提取路由配置的第一个子组件进行渲染 -->
          <router-view></router-view>
        </div>
      </main>
      <!-- 右侧弹出信息呈现区 -->
      <AppAside fixed>
        <!-- 直接使用 DefaultAside 组件进行渲染 -->
        <DefaultAside />
      </AppAside>
    </div>

    <!-- 页脚 -->
    <TheFooter>
      <!--footer-->
      <div>
        <a href="https://coreui.io">CoreUI</a>
        <span class="ml-1">&copy; 2018 creativeLabs.</span>
      </div>
      <div class="ml-auto">
        <span class="mr-1">Powered by</span>
        <a href="https://coreui.io">CoreUI for Vue</a>
      </div>
    </TheFooter>
  </div>
</template>

<script>
  // 导入侧边栏导航数据内容 _nav.js
  import nav from '@/_nav'
  // 导入内置的侧边栏插件，参见导入的插件包 @coreui
  import { Header as AppHeader, SidebarToggler, Sidebar as AppSidebar, SidebarFooter, SidebarForm, SidebarHeader, SidebarMinimizer, SidebarNav, Aside as AppAside, AsideToggler, Footer as TheFooter, Breadcrumb } from '@coreui/vue'
  // 导入顶端下拉的侧边栏（右侧）
  import DefaultAside from './DefaultAside'
  // 导入简单的顶部单击下拉选项内容
  import DefaultHeaderDropdownAccnt from './DefaultHeaderDropdownAccnt'

  export default {
    name: 'DefaultContainer',
    components: {
      AsideToggler,
      AppHeader,
      AppSidebar,
      AppAside,
      TheFooter,
      Breadcrumb,
      DefaultAside,
      DefaultHeaderDropdownAccnt,
      SidebarForm,
      SidebarFooter,
      SidebarToggler,
      SidebarHeader,
      SidebarNav,
      SidebarMinimizer
    },
    data () {
      return {
        nav: nav.items
      }
    },
    computed: {
      name () {
        // 返回当前的路由节点名称
        return this.$route.name 
      },
      list() {
        // 放回当前当前的路由路径节点集合
        return this.$route.matched.filter((route) => route.name || route.meta.label )
      }
    }
  }
</script>
