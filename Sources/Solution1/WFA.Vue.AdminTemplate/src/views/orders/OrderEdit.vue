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
              <b-form-group validated description=" " label="订单名称：" label-for="name" :label-cols="1">
                <b-form-input id="name" v-model="CardForm.name" type="text" autocomplete="name" required placeholder="请输入订单名称"></b-form-input>
              </b-form-group>

              <b-form-group description=" " label="请输入订单编号" label-for="identityCard" :label-cols="1">
                <b-form-input id="identityCard" v-model="CardForm.identityCard" type="text" autocomplete="identityCard" required placeholder="请输入订单编号"></b-form-input>
              </b-form-group>
              <b-form-group description=" " label="订单说明" label-for="initialIntegral" :label-cols="1">
                <b-form-input id="initialIntegral" v-model="CardForm.initialIntegral" type="text" autocomplete="initialIntegral" required placeholder="请输入订单说明"></b-form-input>
              </b-form-group>
              <b-form-group description label="会员等级" label-for="level">
                <b-form-select id="input-3"
                               v-model="CardForm.level"
                               :options = this.levelitem 
                               value-field= id
                               text-field= level
                               required>

                </b-form-select>

              </b-form-group>
          
              <b-form-group description="" label="说明" label-for="description" :label-cols="1">
                <b-form-input id="description" v-model="CardForm.description" type="text" autocomplete="description" required placeholder=""></b-form-input>
              </b-form-group>

                   <b-button type="submit" variant="primary">提交数据</b-button>
              <b-button type="reset" variant="danger">重置表单</b-button>
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
  const uri = 'api/MembershipCard/';

  export default {
    name: 'MembershipEdit',

    // 一般参数定义
    props: {
      caption: {
        type: String,
        default: '编辑商品信息'
      },
    },

    // 数据定义
    data: function () {
      return {
        // 表单数据模型，用于绑定到 b-form 的变量
       
        CardForm: {
          id: '',
          name: "",
          identityCard: "",
          level: [],
          initialIntegral:0,
          description: "",
          orderNumber: ""
        },
      
        levelitem:[],
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
         for(var i in this.levelitem)
        {  
          if(this.levelitem[i].id==this.CardForm.level)
          {
        
           this.CardForm.level=this.levelitem[i]
       
          } 
        }
        this.CardForm.errors = [];
       
        const item = {
          Id: this.CardForm.id,
          Name: this.CardForm.name,
          IdentityCard:this.CardForm.identityCard,
          MembershipLevel: this.CardForm.level,
          Description: this.CardForm.description,
          InitialIntegral: parseInt( this.CardForm.initialIntegral)
        };
         this.$axios.put(uri+this.$route.params.id,item)
        // 返回列表页
         this.$router.go(-1)

       
      },
      // 重置表单
      onReset(evt) {
        evt.preventDefault()
        this.CardForm.name = ''
        this.CardForm.identityCard = ''
        this.CardForm.initialIntegral = ''
        this.CardForm.description = ''
      },
      // 关闭编辑
      closeEdit() {
        this.$router.go(-1)
      }
    },

    // 代码加载后直接执行的方法
    created: function () {

     
        this.levelitem = this.$route.params.level;
       

       var item = this
       this.$axios.get(uri+this.$route.params.id).then(function(res){
       
      
        item.CardForm=res.data
       //item.CardForm = res.data
           item.CardForm.level=  res.data.membershipLevel.id
         
           })   
     
        
 
       
   
    },


  }
</script>

<style scoped>
</style>
