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
                <pre class="m-0">{{PCategoryform.errors}}</pre>
              </b-card>
              <b-form-group validated
                            description="请输入产品类型名称"
                            label="产品类型名称："
                            label-for="name">
                <b-form-input id="name"
                              v-model="PCategoryform.name"
                              type="text"
                              autocomplete="name"
                              required
                              placeholder="请输入产品类型名称"></b-form-input>
              </b-form-group>

              <b-form-group validated
                            description="请输入产品类型简称"
                            label="产品类型简称："
                            label-for="displayName">
                            <b-form-input id="displayName"
                              v-model="PCategoryform.displayName"
                              type="text"
                              autocomplete="displayName"
                              required
                              placeholder="请输入产品类型简称"></b-form-input>
              </b-form-group>

              <b-form-group validated
                            description="请输入类型编号"
                            label="类型编号："
                            label-for="categoryNum">
                            <b-form-input id="categoryNum"
                              v-model="PCategoryform.categoryNum"
                              type="text"
                              autocomplete="categoryNum"
                              required
                              placeholder="请输入类型编号"></b-form-input>
              </b-form-group>

              <b-form-group validated
                            description="请输入产品类型说明"
                            label="产品类型说明："
                            label-for="description">
                            <b-form-input id="description"
                              v-model="PCategoryform.description"
                              type="text"
                              autocomplete="description"
                              required
                              placeholder="请输入产品类型说明"></b-form-input>
              </b-form-group>
              <b-button type="submit" variant="primary">添加产品类型</b-button>
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
    name: "PCategoryIns",
    props: {
      caption: {
        type: String,
        default: "新增产品类型"
      }
    },
    data() {
      return {
       PCategoryform: {
          errors: [],
          name: "",
          description: "",
          categoryNum:"",
          displayName:""
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
        this.PCategoryform.errors = [];
        const item = {
          DisplayName:this.PCategoryform.displayName,
          Name: this.PCategoryform.name,
          Description: this.PCategoryform.description,
          CategoryNum: this.PCategoryform.categoryNum,
        };
       const uri = 'https://localhost:5001/api/PCategory/';  // Web API 的访问服务地址
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
        this.PCategoryform.displayName = "";
        this.PCategoryform.name = "";
        this.PCategoryform.description = "";
        this.PCategoryform.categoryNum = "";
      },
      // 关闭编辑
      closeEdit() {
        this.$router.go(-1);
      }
    },

    // 代码加载后直接执行的方法
    created: function () {

        
      this.directoritem = this.$route.params.director;
   
       //console.log(this.$route)
      this.PCategoryform.Id = newGuid();
     // this.PCategoryform.PCategoryNumber = 1000; // 需要获取最大值后重新赋值
    
       
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
