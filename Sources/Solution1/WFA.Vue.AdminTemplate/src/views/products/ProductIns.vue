<template>
  <div class="animated fadeIn">
    <b-row>
      <b-col sm="12" md="12">
        <transition name="fade">
          <b-card>
            <div slot="header">
              <span style="font-size:20px">{{caption}}</span>
              <div class="card-header-actions">
                <b-input-group>
                  <b-button variant="primary" squared size="sm" @click="closeEdit()">
                    <i class="fa fa-close"></i>
                  </b-button>
                </b-input-group>
              </div>
            </div>

            <b-form @submit="checkForm" @reset="onReset" v-if="show" id="data">

              <b-card class="mt-3" header="数据校验">
                <pre class="m-0">{{ProductForm.errors}}</pre>
              </b-card>
              <b-form-group validated
                            description="请输入产品名称"
                            label="产品名称："
                            label-for="name">
                <b-form-input id="name"
                              v-model="ProductForm.name"
                              type="text"
                              autocomplete="name"
                              required
                              placeholder="请输入产品名称"></b-form-input>
              </b-form-group>

              <b-form-group validated
                            description="请输入产品编号"
                            label="产品编号："
                            label-for="productID">
                            <b-form-input id="productID"
                              v-model="ProductForm.productID"
                              type="text"
                              autocomplete="productID"
                              required
                              placeholder="请输入产品名称"></b-form-input>
              </b-form-group>




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
              <b-form-group validated
                            description="请输入库存量"
                            label="库存量："
                            label-for="inventory">
                            <b-form-input id="inventory"
                              v-model="ProductForm.inventory"
                              type="text"
                              autocomplete="inventory"
                              required
                              placeholder="请输入库存量"></b-form-input>
              </b-form-group>
 
 
 
              <b-form-group description label="产品说明" label-for="description">
                <b-form-input id="description"
                              v-model="ProductForm.description"
                              type="text"
                              autocomplete="description"
                              required
                              placeholder></b-form-input>
              </b-form-group>

              <b-button type="submit" variant="primary">添加产品</b-button>
              <b-button type="reset" variant="danger">重置</b-button>
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

  export default {
    name: "ProductIns",
    props: {
      caption: {
        type: String,
        default: "新建产品信息"
      }
    },
    data() {
      return {
       ProductForm: {
          errors: [],
          productID:"",
          name: "",
          pCategory:"",
          inventory:0,
          orderNum:"",
          order:"",
          description: ""
        },

        pCategoryitem :[],
        orderitem: [],
     
        show: true
      };
    },

    methods: {
        getCookie(name) {
         if (name != null) {
        var value = new RegExp("(?:^|; )" + encodeURIComponent(String(name)) + "=([^;]*)").exec(document.cookie);
        return value ? decodeURIComponent(value[1]) : null;
        }
      },
      // 提交数据
      checkForm(evt) {
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
        this.ProductForm.errors = [];
        const item = {
          ProductID:this.ProductForm.productID,
          Name: this.ProductForm.name,
          Description: this.ProductForm.description,
          Order:this.ProductForm.order,
          PCategory:this.ProductForm.pCategory
          
        };
        console.log(item);
        const uri = 'https://localhost:5001/api/ProductInfo/';  // Web API 的访问服务地址
        this.$axios.post(uri,item)
       // this.$router.go(-1);
        evt.preventDefault();
      },

      onSubmit(evt) {
        evt.preventDefault();
      },
      // 重置表单
      onReset(evt) {
        evt.preventDefault();
        this.ProductForm.name = "";
 
      },
      // 关闭编辑
      closeEdit() {
        this.$router.go(-1);
      }
    },

    // 代码加载后直接执行的方法
    created: function () {

        
      this.pCategoryitem = this.$route.params.pcategory;
      this.orderitem = this.$route.params.order;
       console.log(this.$route)
      this.ProductForm.Id = newGuid();
     // this.ProductForm.orderNumber = 1000; // 需要获取最大值后重新赋值
    
       
      // 生成 guid
      function newGuid() {
        return "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(/[xy]/g, function (
          c
        ) {
          var r = (Math.random() * 16) | 0,
            v = c == "x" ? r : (r & 0x3) | 0x8;
          return v.toString(16);
        });
      }
    }
  };
</script>

<style scoped>
</style>
