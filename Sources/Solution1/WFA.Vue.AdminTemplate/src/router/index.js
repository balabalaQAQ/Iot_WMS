import Vue from 'vue'
import Router from 'vue-router'

// 以下是定义路由值的变量，也可以看成是别名，便于在编程中使用。

// 视图根容器
const DefaultContainer = () => import('@/containers/DefaultContainer')

// 视图
const Dashboard = () => import('@/views/Dashboard')

const Colors = () => import('@/views/theme/Colors')
const Typography = () => import('@/views/theme/Typography')

const Charts = () => import('@/views/Charts')
const Widgets = () => import('@/views/Widgets')

// Views - Components


//订单管理
const OrderIndex = () => import('@/views/orders/OrderIndex')
const OrderIns = () => import('@/views/orders/OrderIns')
const OrderEdit = () => import('@/views/orders/OrderEdit')

//产品管理
const ProductIndex = () => import('@/views/products/ProductIndex')
const ProductIns = () => import('@/views/products/ProductIns')
const ProductEdit = () => import('@/views/products/ProductEdit')
//产品记录管理
const PRecordIndex = () => import('@/views/products/PRecordIndex')
const PRecordIns = () => import('@/views/products/PRecordIns')
const PRecordEdit = () => import('@/views/products/PRecordEdit')
//产品类型管理
const PCategoryIndex = () => import('@/views/products/PCategoryIndex')
const PCategoryIns = () => import('@/views/products/PCategoryIns')
const PCategoryEdit = () => import('@/views/products/PCategoryEdit')

//原料管理
const MaterialsIndex = () => import('@/views/materials/MaterialsIndex')
const MaterialsIns = () => import('@/views/materials/MaterialsIns')
const MaterialsEdit = () => import('@/views/materials/MaterialsEdit')
//原料记录管理
const MCategoryIndex = () => import('@/views/materials/MCategoryIndex')
const MCategoryIns = () => import('@/views/materials/MCategoryIns')
const MCategoryEdit = () => import('@/views/materials/MCategoryEdit')
//原料类型管理
const RMRecordIndex = () => import('@/views/materials/RMRecordIndex')
const RMRecordIns = () => import('@/views/materials/RMRecordIns')
const RMRecordEdit = () => import('@/views/materials/RMRecordEdit')

// Views - Buttons
const StandardButtons = () => import('@/views/buttons/StandardButtons')
const ButtonGroups = () => import('@/views/buttons/ButtonGroups')
const Dropdowns = () => import('@/views/buttons/Dropdowns')
const BrandButtons = () => import('@/views/buttons/BrandButtons')

// Views - Icons
const Flags = () => import('@/views/icons/Flags')
const FontAwesome = () => import('@/views/icons/FontAwesome')
const SimpleLineIcons = () => import('@/views/icons/SimpleLineIcons')
const CoreUIIcons = () => import('@/views/icons/CoreUIIcons')

// Views - Notifications
const Alerts = () => import('@/views/notifications/Alerts')
const Badges = () => import('@/views/notifications/Badges')
const Modals = () => import('@/views/notifications/Modals')

// Views - Pages
const Page404 = () => import('@/views/pages/Page404')
const Page500 = () => import('@/views/pages/Page500')
const Login = () => import('@/views/pages/Login')
const Register = () => import('@/views/pages/Register')

// Users
const Users = () => import('@/views/users/Users')
const User = () => import('@/views/users/User')

// 演示数据处理
const DataList = () => import('@/views/appDemo/DataList')
const DataCreate = () => import('@/views/appDemo/DataCreate')
const DataEdit = () => import('@/views/appDemo/DataEdit')
const DataDetail = () => import('@/views/appDemo/DataDetail')
const DataDelete = () => import('@/views/appDemo/DataDelete')

Vue.use(Router)

// 配置路由
export default new Router({
  mode: 'hash', // 关于路由模式的说明，请参见：  https://router.vuejs.org/api/#mode
  linkActiveClass: 'open active',
  scrollBehavior: () => ({ y: 0 }),
  routes: [
    {
      // 将仪表盘 Dashboard.vue 设置为缺省首页页面进行渲染
      path: '/',
      redirect: '/dashboard',
      name: '首页',
      component: DefaultContainer,
      // 子组件
      children: [
        {
          path: 'dashboard',
          name: 'Dashboard',
          component: Dashboard
        },
        {
          path: 'theme',
          redirect: '/theme/colors',
          name: 'Theme',
          component: {
            render (c) { return c('router-view') }
          },
          children: [
            {
              path: 'colors',
              name: 'Colors',
              component: Colors
            },
            {
              path: 'typography',
              name: 'Typography',
              component: Typography
            }
          ]
        },
        {
          path: 'charts',
          name: 'Charts',
          component: Charts
        },
        {
          path: 'widgets',
          name: 'Widgets',
          component: Widgets
        },
        {
          path: 'users',
          meta: { label: '用户数据列表'},
          component: {
            render (c) { return c('router-view') }
          },
          children: [
            {
              path: '',
              component: Users,
            },
            {
              path: ':id',
              meta: { label: '用户明细数据'},
              name: 'User',
              component: User,
            },
          ]
        },
        {
          path: 'orders',
          redirect: '/orders/OrderIndex',
          name: 'orders',
          component: {
            render (c) { return c('router-view') }
          },
          children: [
            {
              path: 'OrderIndex',
              name: 'OrderIndex',
              component: OrderIndex
            },
            {
              path: 'OrderIns',
              name: 'OrderIns',
              component: OrderIns
            },
            {
              path: 'OrderEdit',
              name: 'OrderEdit',
              component: OrderEdit
            },

          ]
        },
        {
          path: 'products',
          redirect: '/products/ProductIndex',
          name: 'products',
          component: {
            render (c) { return c('router-view') }
          },
          children: [
            {
              path: 'ProductIndex',
              name: 'ProductIndex',
              component: ProductIndex
            },
            {
              path: 'ProductIns',
              name: 'ProductIns',
              component: ProductIns
            },
            {
              path: 'ProductEdit',
              name: 'ProductEdit',
              component: ProductEdit
            },
            {
              path: 'PRecordIndex',
              name: 'PRecordIndex',
              component: PRecordIndex
            },
            {
              path: 'PRecordIns',
              name: 'PRecordIns',
              component: PRecordIns
            },
            {
              path: 'PRecordEdit',
              name: 'PRecordEdit',
              component: PRecordEdit
            },
            {
              path: 'PCategoryIndex',
              name: 'PCategoryIndex',
              component: PCategoryIndex
            },
            {
              path: 'PCategoryIns',
              name: 'PCategoryIns',
              component: PCategoryIns
            },
            {
              path: 'PCategoryEdit',
              name: 'PCategoryEdit',
              component: PCategoryEdit
            },
          ]
        },
        {
          path: 'materials',
          redirect: '/materials/MaterialsIndex',
          name: 'materials',
          component: {
            render (c) { return c('router-view') }
          },
          children: [
            {
              path: 'MaterialsIndex',
              name: 'MaterialsIndex',
              component: MaterialsIndex
            },
            {
              path: 'MaterialsIns',
              name: 'MaterialsIns',
              component: MCategoryIns
            },
            {
              path: 'MaterialsEdit',
              name: 'MaterialsEdit',
              component: MCategoryEdit
            },
            {
              path: 'RMRecordIndex',
              name: 'RMRecordIndex',
              component: RMRecordIndex
            },
            {
              path: 'RMRecordIns',
              name: 'RMRecordIns',
              component: RMRecordIns
            },
            {
              path: 'RMRecordEdit',
              name: 'RMRecordEdit',
              component: RMRecordEdit
            },
            {
              path: 'MCategoryIndex',
              name: 'MCategoryIndex',
              component: MCategoryIndex
            },
            {
              path: 'MCategoryIns',
              name: 'MCategoryIns',
              component: MCategoryIns
            },
            {
              path: 'MCategoryEdit',
              name: 'MCategoryEdit',
              component: MCategoryEdit
            },
          ]
        },
        {
          path: 'icons',
          redirect: '/icons/font-awesome',
          name: 'Icons',
          component: {
            render (c) { return c('router-view') }
          },
          children: [
            {
              path: 'coreui-icons',
              name: 'CoreUI Icons',
              component: CoreUIIcons
            },
            {
              path: 'flags',
              name: 'Flags',
              component: Flags
            },
            {
              path: 'font-awesome',
              name: 'Font Awesome',
              component: FontAwesome
            },
            {
              path: 'simple-line-icons',
              name: 'Simple Line Icons',
              component: SimpleLineIcons
            }
          ]
        },
        {
          path: 'notifications',
          redirect: '/notifications/alerts',
          name: 'Notifications',
          component: {
            render (c) { return c('router-view') }
          },
          children: [
            {
              path: 'alerts',
              name: 'Alerts',
              component: Alerts
            },
            {
              path: 'badges',
              name: 'Badges',
              component: Badges
            },
            {
              path: 'modals',
              name: 'Modals',
              component: Modals
            }
          ]
        },
        // 自定义的组件，正常的业务数据管理的自定义组件一般都放在这个范围内
        {
          path: 'appDemo',
          redirect: '/appDemo/dataList',
          meta: { label: '演示数据列表' },
          name: 'DataList',
          component: {
            render(c) { return c('router-view') }   // 缺省使用 children 数组的第一个
          },
          children: [
            {
              path: 'dataList',
              meta: { label: '演示数据列表' },
              name: 'DataList',
              component: DataList
            },
            {
              path: 'dataCreate',
              meta: { label: '新建数据' },
              name: 'DataCreate',
              component: DataCreate
            },
            {
              path: 'dataEdit/:id',
              meta: { label: '编辑数据' },
              name: 'DataEdit',
              component: DataEdit
            },
            {
              path: 'dataDetail/:id',
              meta: { label: '明细数据' },
              name: 'DataDetail',
              component: DataDetail
            },
            {
              path: 'dataDelete/:id',
              meta: { label: '删除数据' },
              name: 'DataDelete',
              component: DataDelete
            }
          ]
        }
      ]
    },
    {
      path: '/pages',
      redirect: '/pages/404',
      name: 'Pages',
      component: {
        render (c) { return c('router-view') }
      },
      children: [
        {
          path: '404',
          name: 'Page404',
          component: Page404
        },
        {
          path: '500',
          name: 'Page500',
          component: Page500
        },
        {
          path: 'login',
          name: 'Login',
          component: Login
        },
        {
          path: 'register',
          name: 'Register',
          component: Register
        }
      ]
    },

  ]
})
