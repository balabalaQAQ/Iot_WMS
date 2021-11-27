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
                <b-form-input id="name" v-model="OrderForm.name"v-bind:disabled="true" type="text" autocomplete="name" required placeholder=" "></b-form-input>
              </b-form-group>   </br>

              <b-form-group description=" " label="订单编号" label-for="orderNum" :label-cols="1">
                <b-form-input id="orderNum" v-model="OrderForm.orderNum" v-bind:disabled="true" type="text" autocomplete="orderNum" required placeholder=" "></b-form-input>
              </b-form-group>   </br>

              <b-form-group description=" " label="申请时间" label-for="setTime" :label-cols="1">
                <b-form-input id="setTime" v-model="OrderForm.setTime" v-bind:disabled="true" type="text" autocomplete="setTime" required placeholder=" "></b-form-input>
              </b-form-group>   </br>
              
              <b-form-group description=" " label="单价" label-for="price" :label-cols="1">
              <b-form-input id="price" v-model="OrderForm.price" v-bind:disabled="true" type="text" autocomplete="price" required placeholder=" "></b-form-input>
              </b-form-group>   </br>

              <b-form-group description=" " label="总价" label-for="totalPrice" :label-cols="1">
                <b-form-input id="totalPrice" class="form-control" v-model="OrderForm.totalPrice"  v-bind:disabled="true"  type="text" autocomplete="totalPrice" required placeholder=" "></b-form-input>
              </b-form-group>   </br>

              <b-form-group description=" " label="订单说明" label-for="description" :label-cols="1">
                <b-form-input id="description" v-model="OrderForm.description" v-bind:disabled="true" type="text" autocomplete="description" required placeholder=" "></b-form-input>
              </b-form-group>   </br>

              <b-form-group description=" " label="负责人" label-for="director" :label-cols="1">
                <b-form-input id="director" v-model="OrderForm.director" type="text" v-bind:disabled="true" autocomplete="director" required placeholder=" "></b-form-input>
              </b-form-group>   </br>

              <b-form-group description label="当前状态" label-for="status">
                <b-form-select id="input-3"
                               v-model="OrderForm.status"
                               :options = "this.statusitem "
                               value-field= id
                               text-field= status
                               required>

                </b-form-select>

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
  const uri = 'https://localhost:5001/api/PRecord/';  // Web API 的访问服务地址
  export default {
    name: 'PRecordEdit',

    // 一般参数定义
    props: {
      caption: {
        type: String,
        default: '审核操作记录'
      },
    },

    // 数据定义
    data: function () {
      return {
        // 表单数据模型，用于绑定到 b-form 的变量
       
        OrderForm: {
          id:"",
          orderNum:"",
          name: "",
          setTime:"",
          price:0.0,
          totalPrice:0.0,
          description: "",
          status:0,
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
         for(var i in this.statusitem)
        {  
          if(this.statusitem[i]==this.OrderForm.status)
          {
           this.OrderForm.status=i
          } 
        }
        this.OrderForm.errors = [];
       
        const item = {
         Id:this.OrderForm.id,
         Status:Number(this.OrderForm.status),
         OrderNum:this.OrderForm.orderNum,
         Name:this.OrderForm.name,
         Description: this.OrderForm.description,
         SetTime: this.OrderForm.setTime,
         Price: this.OrderForm.price,
         TotalPrice:this.OrderForm.totalPrice,
        };
         this.$axios.put(uri+this.$route.params.id,item)
        // 返回列表页
         this.$router.go(-1)
         evt.preventDefault();
       
      },
      // 重置表单
      onReset(evt) {
        evt.preventDefault()
        this.OrderForm.status = '待审核'
      },
      // 关闭编辑
      closeEdit() {
        this.$router.go(-1)
      }
    },

    // 代码加载后直接执行的方法
    created: function () {
        var status=['待审核', '审核成功','审核失败', '已取消','已完成'];
        this.statusitem = status;
        var item = this;
        if(this.$route.params.id==null)//如果数据已经丢失退出编辑
            this.$router.go(-1)
        else{
          this.$axios.get(uri+this.$route.params.id).then(function(res){
          res.data.status=status[res.data.status];
          item.OrderForm=res.data   })   
        }
       
     },  
  
  }
</script>

<style scoped>
</style>
