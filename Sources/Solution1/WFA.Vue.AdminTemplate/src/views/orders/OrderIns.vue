<template>
  <div class="animated fadeIn">
    <b-row>
      <b-col sm="12" md="12">
        <transition name="fade">
          <b-card>
            <div slot="header">
              <span style="font-size:20px">{{caption}}</span>
            </div>

            <b-form @submit="checkForm" @reset="onReset" v-if="show" id="data">

              <b-card class="mt-3" header="数据校验">
                <pre class="m-0">{{Orderform.errors}}</pre>
              </b-card>
              <b-form-group validated
                            description="请输入订单名称"
                            label="订单名称："
                            label-for="name">
                <b-form-input id="name"
                              v-model="Orderform.name"
                              type="text"
                              autocomplete="name"
                              required
                              placeholder="请输入订单名称"></b-form-input>
              </b-form-group>

              <b-form-group validated
                            description="请输入订单编号"
                            label="订单编号："
                            label-for="name">
                            <b-form-input id="name"
                              v-model="Orderform.name"
                              type="text"
                              autocomplete="name"
                              required
                              placeholder="请输入订单名称"></b-form-input>
              </b-form-group>
 
 
 
              <b-form-group description label="订单说明" label-for="description">
                <b-form-input id="description"
                              v-model="Orderform.description"
                              type="text"
                              autocomplete="description"
                              required
                              placeholder></b-form-input>
              </b-form-group>

              <b-button type="submit" variant="primary">添加订单</b-button>
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
    name: "OrderIns",
    props: {
      caption: {
        type: String,
        default: "新建订单信息"
      }
    },
    data() {
      return {
       Orderform: {
          errors: [],
          orderNum:"",
          name: "",
          description: ""
        },
        directoritem: [],
        revieweritem: [],
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
       
       
        this.Orderform.errors = [];
        const item = {
        //  Id: this.Orderform.Id,
          OrderNum:this.Orderform.orderNum,
          Name: this.Orderform.name,
          Description: this.Orderform.description,
          SetTime: "2000-06-09"
        //  Status:0,
        //  IsPseudoDelete:false
        };
       const uri = 'https://localhost:5001/api/Order';  // Web API 的访问服务地址
      console.log(item);
      //  const uri ='api/WeatherForecast'
        this.$axios.post(uri,item)

        this.$router.go(-1);

        evt.preventDefault();
      },

      onSubmit(evt) {

        evt.preventDefault();




      },
      // 重置表单
      onReset(evt) {
        evt.preventDefault();
        this.Orderform.name = "";
 
      },
      // 关闭编辑
      closeEdit() {
        this.$router.go(-1);
      }
    },

    // 代码加载后直接执行的方法
    created: function () {

        
      this.directoritem = this.$route.params.director;
   
       console.log(this.$route)
      this.Orderform.Id = newGuid();
     // this.Orderform.orderNumber = 1000; // 需要获取最大值后重新赋值
    
       
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
