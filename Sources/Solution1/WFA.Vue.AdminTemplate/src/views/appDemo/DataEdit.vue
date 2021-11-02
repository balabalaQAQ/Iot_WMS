<template>
  <div class="animated fadeIn">
    <b-row>
      <b-col sm="12" md="12">
        <transition name="fade">
          <b-card>
            <div slot="header">
              <span style="font-size:20px"> {{caption}} </span>
              <div class="card-header-actions">
                <b-input-group>
                  <b-button variant="primary" squared size="sm" @click="closeEdit()">
                    <i class="fa fa-close"></i>
                  </b-button>
                </b-input-group>
              </div>
            </div>

            <b-form @submit="onSubmit" @reset="onReset" v-if="show">
              <b-form-group validated description="请输入真实姓名" label="姓名：" label-for="name" :label-cols="1">
                <b-form-input id="name" v-model="userForm.name" type="text" autocomplete="name" required placeholder="请输入姓名"></b-form-input>
              </b-form-group>
              <b-form-group validated  description="" label="注册日期：" label-for="AdmissionTime" :label-cols="1">
                <b-form-input id="AdmissionTime" v-model="userForm.AdmissionTime" type="date" autocomplete="AdmissionTime" required placeholder="" ></b-form-input>
              </b-form-group>
                 <b-form-group validated  description="" label="最后使用日期：" label-for="lastTime" :label-cols="1">
                <b-form-input id="lastTime" v-model="userForm.lastTime" type="date" autocomplete="lastTime" required placeholder=""></b-form-input>
              </b-form-group>
              <b-form-group description="" label="积分" label-for="integral" :label-cols="1">
                <b-form-input id="integral" v-model="userForm.integral" type="text" autocomplete="integral" required placeholder=""></b-form-input>
              </b-form-group>
        

              <b-button type="submit" variant="primary">提交数据</b-button>
              <b-button type="reset" variant="danger">重置表单</b-button>

            </b-form>

            <!-- 调试期间的数据呈现 -->
            <b-card class="mt-3" header="数据结果">
              <pre class="m-0">{{ userForm }}</pre>
            </b-card>
          </b-card>

        </transition>
      </b-col>
    </b-row>
  </div>
</template>

<script>
  // 导入数据源
  import demoData from './DemoData'

  export default {
    name: 'DataEdit',

    // 一般参数定义
    props: {
      caption: {
        type: String,
        default: '编辑用户信息'
      },
    },

    // 数据定义
    data() {
      return {
        // 表单数据模型，用于绑定到 b-form 的变量
        userForm: {
          id         : '',
          orderNumber: 0,
          name       : '',
          AdmissionTime : '',
          lastTime       : '',
          integral     : ''
        },
        show: true
      }
    },

    // 计算属性
    computed: {
    },

    // 方法
    methods: {
      // 提交数据
      onSubmit(evt) {
        // 关闭表单按钮缺省提交事件
        evt.preventDefault()
        // 获取表单值并转换为 json 字符串，以便提交
        alert(JSON.stringify(this.userForm))

        // 更新表单关联的数据对象
        let user = demoData.find(user => user.id === this.$route.params.id)
        // 从表单中像选定的数据元素赋值
        user.name       = this.userForm.name
        user.AdmissionTime = this.userForm.AdmissionTime
        user.lastTime      = this.userForm.lastTime
        user.integral     = this.userForm.integral

        // 返回列表页
        this.$router.go(-1)
      },
      // 重置表单
      onReset(evt) {
        evt.preventDefault()
        this.userForm.name        = ''
        this.userForm.AdmissionTime  = ''
        this.userForm.lastTime        = ''
        this.userForm.integral      = ''
      },
      // 关闭编辑
      closeEdit() {
        this.$router.go(-1)
      }
    },

    // 代码加载后直接执行的方法
    created: function () {
      // 根据传入的 id 获取待处理的数据
      let user = demoData.find(user => user.id === this.$route.params.id)
      // 为表单模型赋值
      this.userForm.id          = user.id
      this.userForm.orderNumber = user.orderNumber
      this.userForm.name        = user.name
      this.userForm.AdmissionTime  = user.AdmissionTime
      this.userForm.lastTime        = user.lastTime
      this.userForm.integral      = user.integral
    }
  }
</script>

<style scoped>
</style>
