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
              <b-form-group validated description=" " label="产品名称：" label-for="name" :label-cols="1">
                <b-form-input id="name" v-model="ProductForm.name"  type="text" autocomplete="name" required placeholder=" "></b-form-input>
              </b-form-group>   </br>

              <b-form-group description=" " label="产品编号" label-for="productID" :label-cols="1">
                <b-form-input id="productID" v-model="ProductForm.productID"   type="text" autocomplete="productID" required placeholder=" "></b-form-input>
              </b-form-group>   </br>
 

              <b-form-group description=" " label="库存量" label-for="inventory" :label-cols="1">
                <b-form-input id="inventory" v-model="ProductForm.inventory"   type="text" autocomplete="inventory" required placeholder=" "></b-form-input>
              </b-form-group>   </br>
              
 
 

              <b-form-group description label="产品类别" label-for="pCategory">
                <b-form-select id="input-3"
                               v-model="ProductForm.pCategory"
                               :options = this.pCategoryitem 
                               value-field= id
                               text-field= name
                               required>

                </b-form-select>

              </b-form-group>
              

               <b-form-group description label="所属订单号" label-for="order">
                <b-form-select id="input-3"
                               v-model="ProductForm.order"
                               :options = this.orderitem 
                               value-field= id
                               text-field= orderNum
                               required>

                </b-form-select>

              </b-form-group>
        
              <b-form-group description label="产品说明" label-for="description">
                <b-form-input id="description"
                              v-model="ProductForm.description"
                              type="text"
                              autocomplete="description"
                              required
                              placeholder></b-form-input>
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
              <pre class="m-0">{{ MalloFrm }}</pre>
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
  const uri = 'https://localhost:5001/api/ProductInfo/';  // Web API 的访问服务地址
  export default {
    name: 'ProductEdit',

    // 一般参数定义
    props: {
      caption: {
        type: String,
        default: '审核订单信息'
      },
    },

    // 数据定义
    data: function () {
      return {
        // 表单数据模型，用于绑定到 b-form 的变量
       
      ProductForm: {
          id:"",
          errors: [],
          productID:"",
          name: "",
          pCategory:"",
          inventory:0,
          orderNumber:"",
          order:"",
          description: ""
        },
        pCategoryitem :[],
        orderitem: [],
        
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
         
        this.ProductForm.errors = [];
         for(var i in this.pCategoryitem)
        {  
          if(this.pCategoryitem[i].id==this.ProductForm.pCategory)
          {
        
           this.ProductForm.pCategory=this.pCategoryitem[i]
       
          } 
        }
       for(var i in this.orderitem)
        {  
          if(this.orderitem[i].id==this.ProductForm.order)
          {
        
           this.ProductForm.order=this.orderitem[i]
       
          } 
        }
        const item = {
          Id:this.ProductForm.id,
          ProductID:this.ProductForm.productID,
          Name: this.ProductForm.name,
          Description: this.ProductForm.description,
          Order:this.ProductForm.order,
          PCategory:this.ProductForm.pCategory,
          Inventory:this.ProductForm.inventory
        };
         this.$axios.put(uri+this.$route.params.id,item)
        // 返回列表页
         this.$router.go(-1)
         evt.preventDefault();
       
      },
      // 重置表单
      onReset(evt) {
        evt.preventDefault()
      },
      // 关闭编辑
      closeEdit() {
        this.$router.go(-1)
      }
    },

    // 代码加载后直接执行的方法
    created: function () {
           
        this.pCategoryitem = this.$route.params.pcategory;
        this.orderitem = this.$route.params.order;
   
 
        var item = this;
        if(this.$route.params.id==null)//如果数据已经丢失退出编辑
            this.$router.go(-1)
        else{
          this.$axios.get(uri+this.$route.params.id).then(function(res){
  
          item.ProductForm=res.data
              
          item.ProductForm.pCategory=res.data.pCategory.id;
          item.ProductForm.order=res.data.order.id;
           console.log(item.ProductForm);
         // console.log(item);
          })   
  
        }
       
     },  
  
  }
</script>

<style scoped>
</style>
