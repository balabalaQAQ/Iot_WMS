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


              <b-form-group validated
                            description="请输入记录名称"
                            label="记录名称："
                            label-for="name">
                <b-form-input id="name"
                              v-model=" PRecordForm.name"
                              type="text"
                              autocomplete="name"
                              required
                              placeholder="请输入记录名称"></b-form-input>
              </b-form-group>



              <b-form-group validated
                            description="请输入操作数量"
                            label="操作数量："
                            label-for="setNum">
                            <b-form-input
                              @input="anysetNum" 
                              id="setNum"
                              maxlength="5"
                              v-model="PRecordForm.setNum"
                              onkeyup="value=value.replace(/[^\d]/g,'')" 
                              type="text"
                              autocomplete="setNum"
                              required
                              placeholder="请输入操作数量"></b-form-input>
              </b-form-group>

    
              <b-form-group description label="操作类型" label-for="setType">
                  <b-form-select id="input-3"
                                @input="anysetType" 
                                v-model=" PRecordForm.setType"
                                :options = this.setTypeitem 
                                value-field= id
                                text-field= setType
                                required>
                  </b-form-select>
                </b-form-group>
              <b-form-group validated
                         
                            label="产品名称："
                            label-for="pname">
                            <b-form-input id="pname"
                              v-model=" PRecordForm.pname"
                              type="text"
                              autocomplete="pname"
                              required
                              v-bind:disabled="true"  ></b-form-input>
              </b-form-group>
               <b-form-group validated
                         
                            label="产品当前库存："
                            label-for="inventory">
                            <b-form-input id="inventory"
                              v-model=" PRecordForm.inventory"
                              type="text"
                              autocomplete="inventory"
                              required
                              v-bind:disabled="true"  ></b-form-input>
              </b-form-group>
              <b-form-group validated
                            label="销售总价：(元)"
                            label-for="totalPrice">
                            <b-form-input id="totalPrice"
                              v-model=" PRecordForm.totalPrice"
                              type="text"
                              autocomplete="totalPrice"
                              required
                              v-bind:disabled="true"></b-form-input>
              </b-form-group>
               <b-form-group validated
                            label="单价："
                            label-for="price">
                            <b-form-input id="price"
                              v-model=" PRecordForm.price"
                              type="text"
                              autocomplete="price"
                              required
                              v-bind:disabled="true"  ></b-form-input>
              </b-form-group>
              <b-form-group description label="操作说明" label-for="description">
                <b-form-input id="description"
                              v-model=" PRecordForm.description"
                              type="text"
                              autocomplete="description"
                              required
                              placeholder></b-form-input>
              </b-form-group>

              <b-button type="submit" variant="primary">完成操作</b-button>
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
    name: "PRecordIns",
    props: {
      caption: {
        type: String,
        default: "新建产品操作记录"
      }
    },
    data() {
      return {
        PRecordForm: {
          errors: [],
          pid:"",
          inventory:0,
          ordernum:"",
          name: "",
          pname:"",
          totalPrice:0,
          price:0,
          setNum:1,
          setType:0,
          description: ""
        },
        setTypeitem:[],
        pitem:[],
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
      anysetNum(e){//监听输入的操作数量，使其在合法范围内
      if((this.PRecordForm.setNum>this.PRecordForm.inventory)&&this.PRecordForm.setType=="出库"){
          this.$nextTick(() => {//略微延时后 重置数据 ，若无延迟则数据渲染无法更新
          this.PRecordForm.setNum = this.PRecordForm.inventory
          this.PRecordForm.totalPrice=this.PRecordForm.setNum*this.PRecordForm.price;
          });
        }
      },
      anysetType(e){//监听出入库操作 对相关影响参数进行修改
        if(e=="入库"){//入库不需要计算销售总价
          this.PRecordForm.totalPrice=0;
           console.log(this.PRecordForm.setNum,0 );
          this.PRecordForm.setNum ++;
           console.log(this.PRecordForm.setNum ,1);
          this.$nextTick(() => {//略微延时后 重置数据 ，若无延迟则数据渲染无法更新
          this.PRecordForm.setNum -= 1;
            console.log(this.PRecordForm.setNum,3 );
           });
          this.PRecordForm.totalPrice=0;
        }
        else{
            this.PRecordForm.setNum ++;
            this.$nextTick(() => {//略微延时后 重置数据 ，若无延迟则数据渲染无法更新
            this.PRecordForm.setNum -= 1;
            if(this.PRecordForm.setNum>this.PRecordForm.inventory){
                this.PRecordForm.setNum = this.PRecordForm.inventory//更新操作数量
             }
            this.PRecordForm.totalPrice=this.PRecordForm.setNum*this.PRecordForm.price;//更新总价
          
            });
        }
      },
      // 提交数据
      checkForm(evt) {
        for(var i in this.setTypeitem)
        {  
          if(this.setTypeitem[i]==this. PRecordForm.setType)
          {
           this. PRecordForm.setType=i
          } 
        }
        if(this.PRecordForm.setType==1&&this.PRecordForm.setNum>this.PRecordForm.inventory){//出库量大于入库量
             this.PRecordForm.setNum==this.PRecordForm.inventory;
        }
        if(this. PRecordForm.setType==0){//入库
            this.PRecordForm.inventory+=Number(setNum)
        }
        else{//入库
            this.PRecordForm.inventory-=setNum
        }
       
        this. PRecordForm.errors = [];
        const item = {
          Name: this. PRecordForm.name,
          Description: this. PRecordForm.description,
          setType:Number(this.PRecordForm.setType),
          SetNum:Number(this.PRecordForm.setNum),
          totalPrice:Number(this.PRecordForm.totalPrice),
          Price:Number(this.PRecordForm.price),
          ProductInfo: this.pitem
        };
       const uri = 'https://localhost:5001/api/PRecord/';
       const uri2 = 'https://localhost:5001/api/ProductInfo/';   // Web API 的访问服务地址
       console.log(item);
         this.$axios.post(uri,item);
      // this.$axios.put(uri2+this.$route.params.id,"111");
        this.$router.go(-1);
        evt.preventDefault();
      },

      onSubmit(evt) {
        evt.preventDefault();
      },
      // 重置表单
      onReset(evt) {
        evt.preventDefault();
        this. PRecordForm.name = "";
 
      },
      // 关闭编辑
      closeEdit() {
        this.$router.go(-1);
      }
    },

    // 代码加载后直接执行的方法
    created: function () {

      this.PRecordForm=this.$route.params.item;
      var setType=['入库',"出库"];
      this.setTypeitem=setType;
      this.pitem= this.$route.params.item;

      this.PRecordForm.setType=setType[0];
      this.PRecordForm.pname=this.$route.params.name;
      console.log(this.$route.params.item);
      if(this.$route.params.name==null){
          this.$router.go(-1);
      }
      this. PRecordForm.Id = newGuid();
     // this. PRecordForm.orderNumber = 1000; // 需要获取最大值后重新赋值
    
       
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
