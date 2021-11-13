/*
 * 如果希望从后端获取动态导航菜单数据，可以从这里处理访问后端的数据，获取 items 数据
 */
export default {
  items: [
    {
      name: '数字仪表盘',
      url: '/dashboard',
      icon: 'icon-speedometer',
      badge: {
        variant: 'primary',
        text: 'NEW'
      }
    },
    {
      title: true,
      name: '主题',
      class: '',
      wrapper: {
        element: '',
        attributes: {}
      }
    },
    {
      name: '颜色',
      url: '/theme/colors',
      icon: 'icon-drop'
    },
    {
      name: '字体',
      url: '/theme/typography',
      icon: 'icon-pencil'
    },
    {
      title: true,
      name: '功能',
      class: '',
      wrapper: {
        element: '',
        attributes: {}
      }
    },
    {
      name: '订单管理',
      url: '/orders',
      icon: 'icon-puzzle',
      children: [
        {
          name: '订单记录',
          url: '/orders/OrderIndex',
          icon: 'icon-puzzle'
        },
        {
          name: '个人购卡',
          url: '/base/carousels',
          icon: 'icon-puzzle'
        },
        {
          name: '团体购卡',
          url: '/base/carousels',
          icon: 'icon-puzzle'
        },
        {
          name: '会员信息',
          url: '/base/collapses',
          icon: 'icon-puzzle'
        },
        {
          name: '会员充值',
          url: '/base/forms',
          icon: 'icon-puzzle'
        },
      ]
    },
    {
      name: '产品管理',
      url: '/products',
      icon: 'icon-cursor',
      children: [
        {
          name: '产品信息',
          url: '/products/ProductIndex',
          icon: 'icon-cursor'
        },
        {
          name: '产品记录',
          url: '/products/PRecordIndex',
          icon: 'icon-cursor'
        },
        {
          name: '产品类型',
          url: '/products/PCategoryIndex',
          icon: 'icon-cursor'
        },
      ]
    },
    {
      name: '超市管理',
      url: '/icons',
      icon: 'icon-pie-chart',
      children: [
        {
          name: '商品信息',
          url: '/icons/coreui-icons',
          icon: 'icon-star'
        },
        {
          name: '商品入库',
          url: '/icons/flags',
          icon: 'icon-star'
        },
        {
          name: '商品销售',
          url: '/icons/font-awesome',
          icon: 'icon-star'
        },
        {
          name: '商品库存',
          url: '/icons/simple-line-icons',
          icon: 'icon-star'
        }
        ,{
          name: '销售查看',
          url: '/icons/simple-line-icons',
          icon: 'icon-star'
        }
      ]
    },
    {
      name: '餐饮管理',
      url: '/notifications',
      icon: 'icon-bell',
      children: [
        {
          name: '菜单信息',
          url: '/notifications/alerts',
          icon: 'icon-bell'
        },
        {
          name: '餐饮消费',
          url: '/notifications/badges',
          icon: 'icon-bell'
        },
        {
          name: '餐饮查看',
          url: '/notifications/modals',
          icon: 'icon-bell'
        }
      ]
    },
    {
      name: '财务管理',
      url: '/notifications',
      icon: 'icon-bell',
      children: [
        {
          name: '个人结算',
          url: '/notifications/alerts',
          icon: 'icon-bell'
        },
        {
          name: '团体结算',
          url: '/notifications/badges',
          icon: 'icon-bell'
        },
        {
          name: '计算汇总',
          url: '/notifications/modals',
          icon: 'icon-bell'
        },
        {
          name: '个人未结算',
          url: '/notifications/modals',
          icon: 'icon-bell'
        },
        {
          name: '团体未结算',
          url: '/notifications/modals',
          icon: 'icon-bell'
        },
        {
          name: '售票员对账',
          url: '/notifications/modals',
          icon: 'icon-bell'
        },
      ]
    },
    {
      name: '数据清空',
      url: '/notifications',
      icon: 'icon-bell',
      children: [
        {
          name: '数据清空',
          url: '/notifications/alerts',
          icon: 'icon-bell'
        },
      ]
    },
    {
      divider: true
    },
    {
      title: true,
      name: '外加样例'
    },
    {
      name: '页面',
      url: '/pages',
      icon: 'icon-star',
      children: [
        {
          name: '登录页面',
          url: '/pages/login',
          icon: 'icon-star'
        },
        {
          name: '注册页面',
          url: '/pages/register',
          icon: 'icon-star'
        },
        {
          name: '404 错误',
          url: '/pages/404',
          icon: 'icon-star'
        },
        {
          name: '500 错误',
          url: '/pages/500',
          icon: 'icon-star'
        }
      ]
    },
    {
      name: '禁用',
      url: '/dashboard',
      icon: 'icon-ban',
      badge: {
        variant: 'secondary',
        text: 'NEW'
      },
      attributes: {  disabled: true  },
    },
    {
      divider: true
    },
    {
      title: true,
      name: '自定义App UI 示例'
    },
    {
      name: '应用实现示例',
      url: '/appDemo',
      icon: 'icon-star',
      children: [
        {
          name: '常规数据处理演示',
          url: '/appDemo/dataList',
          icon: 'icon-star'
        },
      ]
    },

    //{
    //  name: 'Download CoreUI',
    //  url: 'http://coreui.io/vue/',
    //  icon: 'icon-cloud-download',
    //  class: 'mt-auto',
    //  variant: 'success',
    //  attributes: { target: '_blank', rel: 'noopener' }
    //},
    //{
    //  name: '测试 Try CoreUI PRO',
    //  url: 'http://coreui.io/pro/vue/',
    //  icon: 'icon-layers',
    //  variant: 'danger',
    //  attributes: { target: '_blank', rel: 'noopener' }
    //},
  ]
}
