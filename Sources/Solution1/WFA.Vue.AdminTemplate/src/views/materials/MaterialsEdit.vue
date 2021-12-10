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
                <b-form-input id="name" v-model="ProductForm.name"  type="text" autocomplete="name" required placeholder=" " maxlength="30"></b-form-input>
              </b-form-group>   </br>

              <b-form-group description=" " label="产品编号" label-for="productID" :label-cols="1">
                <b-form-input id="productID" v-model="ProductForm.productID"   type="text" autocomplete="productID" required placeholder=" " maxlength="30"></b-form-input>
              </b-form-group>   </br>
 
              <b-form-group description=" " label="库存量" label-for="inventory" :label-cols="1">
                <b-form-input id="inventory" v-model="ProductForm.inventory"    maxlength="5"
                  onkeyup="value=value.replace(/[^\d]/g,'')"   type="text" autocomplete="inventory" required placeholder=" "></b-form-input>
              </b-form-group>   </br>
              
              <b-form-group description=" " label="单价" label-for="price" :label-cols="1">
                <b-form-input id="price"  @input="anyprice"  v-model="ProductForm.price"    maxlength="9"
                  @keyup="ProductForm.price=ProductForm.price.toString().replace().replace(/\.{2,}/g,'.').replace('.','$#$').replace(/\./g,'').replace('$#$','.')" 
                 type="text" autocomplete="price" required placeholder=" "></b-form-input>
              </b-form-group> </br>

              <b-form-group description=" " label="产品类别" label-for="pCategory":label-cols="1">
                <b-form-select id="input-3"
                               v-model="ProductForm.pCategory"
                               :options = "this.pCategoryitem "
                               value-field= id
                               text-field= name
                               required>
                </b-form-select>
              </b-form-group>

              <b-form-group description=" " label="产品说明" label-for="description" :label-cols="1">
                <b-form-input id="description"
                              v-model="ProductForm.description"
                              type="text"
                              autocomplete="description"
                              required
                              placeholder maxlength="150"></b-form-input>
              </b-form-group>

              </br>
              </br>
              </br>
             <b-row class="justify-content-center">
              <b-button type="submit" variant="primary">提交数据</b-button>&nbsp;&nbsp;&nbsp;
              <b-button type="reset" variant="danger">重置表单</b-button>
            </b-row>
            </b-form>
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
    name: 'MaterialsEdit',

    // 一般参数定义
    props: {
      caption: {
        type: String,
        default: '编辑产品信息'
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
          price:0.0,
          pCategory:"",
          inventory:0,
          description: ""
        },
        pCategoryitem :[],
        show: true
      }
    },
    // 计算属性
    computed: {
    },
    // 方法
    methods: {
      anyprice(e){//监听单价格式 
        if(e.length > 1 && e.substr(0,1) ==0 && e.substr(1,1) !='.'){//首位不能为0，会被后面输入的数直接覆盖
            this.$nextTick(() => {
                this.ProductForm.price= e.substr(1,1)
            });
        }
        if(e.substr(0,1)=="." && e!=''){//若首位为·则转换为0
            this.$nextTick(() => {
                  this.ProductForm.price= parseFloat(0)
            });
        }
         if(e.length > 3){//长度大于3时开始检测，使其小数只能保留两位
          this.$nextTick(() => {
            this.ProductForm.price = (e.match(/^\d*(\.?\d{0,2})/g)[0]) || null
          });
         }
      },
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
        const item = {
          Id:this.ProductForm.id,
          ProductID:this.ProductForm.productID,
          Name: this.ProductForm.name,
          Description: this.ProductForm.description,
          PCategory:this.ProductForm.pCategory,
          Inventory:this.ProductForm.inventory,
          Price:this.ProductForm.price
        };
         this.$axios.put(uri+this.$route.params.id,item)
         // 返回列表页
         this.$router.go(-1)
         evt.preventDefault();
       
      },
      // 重置表单
      onReset(evt) {
        evt.preventDefault()
        this.pCategoryitem = this.$route.params.pcategory;
        var item = this;
        if(this.$route.params.id==null)//如果数据已经丢失退出编辑
            this.$router.go(-1)
        else{
          this.$axios.get(uri+this.$route.params.id).then(function(res){
          item.ProductForm=res.data  
          item.ProductForm.pCategory=res.data.pCategory.id;
          })   
  
        }
      },
      // 关闭编辑
      closeEdit() {
        this.$router.go(-1)
      }
    },

    // 代码加载后直接执行的方法
    created: function () {
        this.pCategoryitem = this.$route.params.pcategory;
        var item = this;
        if(this.$route.params.id==null)//如果数据已经丢失退出编辑
            this.$router.go(-1)
        else{
          this.$axios.get(uri+this.$route.params.id).then(function(res){
          item.ProductForm=res.data  
          item.ProductForm.pCategory=res.data.pCategory.id;
          })   
  
        }
       
     },  
  
  }
</script>

<style scoped>
</style>
