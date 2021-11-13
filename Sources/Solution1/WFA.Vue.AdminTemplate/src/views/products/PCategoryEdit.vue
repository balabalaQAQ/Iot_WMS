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
              <b-form-group validated description="请输入产品类型名称" label="类型名称：" label-for="name" :label-cols="1">
                <b-form-input id="name" v-model="PCategoryForm.name" type="text" autocomplete="name" required placeholder="请输入产品类型名称"></b-form-input>
              </b-form-group>
              <b-form-group validated description="请输入产品类型简称" label="类型简称：" label-for="displayName" :label-cols="1">
                <b-form-input id="displayName" v-model="PCategoryForm.displayName" type="text" autocomplete="displayName" required placeholder="请输入产品类型简称"></b-form-input>
              </b-form-group>
              <b-form-group validated description="请输入类型编号" label="类型编号：" label-for="categoryNum" :label-cols="1">
                <b-form-input id="categoryNum" v-model="PCategoryForm.categoryNum" type="text" autocomplete="categoryNum" required placeholder="请输入产品类型编号"></b-form-input>
              </b-form-group>
              <b-form-group validated description="请输入产品类型说明" label="类型说明：" label-for="description" :label-cols="1">
                <b-form-input id="description" v-model="PCategoryForm.description" type="text" autocomplete="description" required placeholder="请输入产品类型说明"></b-form-input>
              </b-form-group>
        
              </br>
              </br>
              </br>
             <b-row class="justify-content-center">
              <b-button type="submit" variant="primary">提交数据</b-button>&nbsp;&nbsp;&nbsp;
              <b-button type="reset" variant="danger">重置表单</b-button>
            </b-row>
            </b-form>

            <!-- 调试期间的数据呈现 -->
            <!--   <b-card class="mt-3" header="数据结果">
              <pre class="m-0">{{ MallForm }}</pre>
            </b-card>
          </b-card>
          -->
          </b-card>

        </transition>
      </b-col>
    </b-row>
  </div>
</template>

<script>
  // 导入数据源
  const uri = 'https://localhost:5001/api/PCategory/';  // Web API 的访问服务地址
  export default {
    name: 'PCategoryEdit',

    // 一般参数定义
    props: {
      caption: {
        type: String,
        default: '编辑产品类型信息'
      },
    },

    // 数据定义
    data: function () {
      return {
        // 表单数据模型，用于绑定到 b-form 的变量
       
        PCategoryForm: {
          id:"",
          name: "",
          description: "",
          categoryNum:"",
          displayName:"",
          director:""
        },
        statusitem:[],
        
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
        this.PCategoryForm.errors = [];
       
        const item = {
         Id:this.PCategoryForm.id,
       
         Name:this.PCategoryForm.name,
         Description: this.PCategoryForm.description,
         CategoryNum: this.PCategoryForm.categoryNum,
         DisplayName: this.PCategoryForm.displayName,
        };
         this.$axios.put(uri+this.$route.params.id,item)
        // 返回列表页
         this.$router.go(-1)
         evt.preventDefault();
       
      },
      // 重置表单
      onReset(evt) {
        evt.preventDefault()
        this.PCategoryForm.status = '待审核'
      },
      // 关闭编辑
      closeEdit() {
        this.$router.go(-1)
      }
    },

    // 代码加载后直接执行的方法
    created: function () {
       
        var item = this;
        if(this.$route.params.id==null)//如果数据已经丢失退出编辑
            this.$router.go(-1)
        else{
          this.$axios.get(uri+this.$route.params.id).then(function(res){
          item.PCategoryForm=res.data   })   
        }
       
     },  
  
  }
</script>

<style scoped>
</style>
