<template>
   <div class="animated fadeIn">
    <b-row>
      <b-col sm="12" md="12">
        <transition name="fade">
          <b-card>
            <!-- 数据列表表头 -->
            <div slot="header">
              <span style="font-size:20px">{{caption}}</span>
              <div class="card-header-actions">
                <b-input-group>
                  <b-form-input id="searchText" type="text" placeholder="按订单名称、订单号"></b-form-input>
                  <b-input-group-append>
                    <b-button variant="primary" size="sm"  @click="searchData(mumitems)">查询</b-button>
                  </b-input-group-append>&nbsp;
                  <b-button method="POST" variant="primary" squared size="sm" @click="createData()">
                    <i class="fa fa-lightbulb-o"></i>&nbsp;新建数据
                  </b-button>
                </b-input-group>
              </div>
            </div>
            <!-- 使用 bootstrapVue table 控件处理列表 -->
            <b-table :hover="hover"
                     :striped="striped"
                     :bordered="bordered"
                     :small="small" 
                     :fixed="fixed"
                     responsive="sm"
                     :items="getmumitems"
                     :fields="fields"
                     :current-page="currentPage"
                     :per-page="perPage">
              <!-- 数据操作 -->
              <template slot="operation" slot-scope="data">
                <b-button variant="primary" size="sm" @click="editData(data.item.id)">详情</b-button>&nbsp;&nbsp;&nbsp;
                <b-button variant="danger" size="sm" @click="deleteData(data.item.id)">删除</b-button>
              </template>
            </b-table>

            <!-- 分页导航 -->

             <nav>
              <b-pagination
                size="sm"
                :total-rows="getRowCount(mumitems)"
                :per-page="perPage"
                v-model="currentPage"
                prev-text="前一页"
                next-text="下一页"
                hide-goto-end-buttons
                align="right"
              
              />
            </nav>
          </b-card>
        </transition>
      </b-col>
    </b-row>
  </div>
</template>
<script src="./site.js" asp-append-version="true"></script>

<script>

function displayData(mumitems){//对显示的数据进行预处理
      var setTypeitem=['入库',"出库"];
    for( var i=0;i< mumitems.length;i++){
      mumitems[i].setType=setTypeitem[mumitems[i].setType];
      //避免一些数据太长的影响
      if(mumitems[i].description.length>=10)
          mumitems[i].description=mumitems[i].description.substr(0,20)+"..."
      if(mumitems[i].name.length>=10)
          mumitems[i].name=mumitems[i].name.substr(0,10)+"..."
    }
    return mumitems;
  }
  // const uri = '/WeatherForecast';   // Web API 的访问服务地址
const uri ='https://localhost:5001/api/PRecord/';
var flag=0; //查询状态
//import { shuffleArray } from "@/shared/utils";
 // import Oidc from "oidc-client" ;

  export default {
    name: "PRecordIndex",
    props: {
      // 列表的表格标题
      caption: {
        type: String,
        default: "产品操作记录"
      },
      hover: {
        type: Boolean,
        default: true
      },
      striped: {
        type: Boolean,
        default: false
      },
      bordered: {
        type: Boolean,
        default: true
      },
      small: {
        type: Boolean,
        default: true
      },
      fixed: {
        type: Boolean,
        default: false
      }
    },

    data: function () {
       
      return {
        // 绑定数据
        //  items: demoData.filter((test) => test.orderNumber < 1200),  // 提取 id < 42 的全部数据

        mumitems: [],//初始数据集，用于显示
        saveitems:[],//用于保存原数据集
        searchitems:[],//查询后的数据集
        fields: [
          { key: "orderNumber", label: "序号" },
      
          { key: "name", label: "记录名称" },
          { key: "description", label: "记录描述" },
          { key: "setTime", label: "操作时间" },
          { key: "setType", label: "操作类型" },
          { key: "setUserName", label: "操作人" },
          { key: "setNum", label: "数量" },
          { key: "productInfo.name", label: "产品名" },
          { key: "totalPrice", label: "总价" },
          { key: "operation", label: "操作" }
        ],
     
        currentPage: 1, // 当前页
        perPage: 10, // 每页数据数量
        totalRows: 0 // 总的行数
      };
    },
 

    computed: {
      getmumitems: function () {
       var item=this
       this.$axios.get(uri).then(function(res){
              if(flag==0)
                item.mumitems=res.data;
              else//进入查询
                item.mumitems=[...item.saveitems];//数组数据类型转化
       })
       return displayData(item.mumitems)
      },
    },
    methods: {    
      getRowCount(mumitems) {
        return mumitems.length;
      },
      searchData(mumitems){
        flag=1;
        var item=this;
        item.mumitems.splice(0,item.mumitems.length);
        item.saveitems.splice(0,item.saveitems.length);
        const searchTextbox = document.getElementById('searchText').value.trim();//获取输入文本框的内容
        this.$axios.get(uri).then(function(res){
        if(searchTextbox==''||searchTextbox==undefined||searchTextbox==null){//判读是否为空
              item.mumitems=item.saveitems = displayData(res.data)
              flag=0;
         }
        else{
           var count=0;
           for(var i=0;i<res.data.length;i++){        
           if (res.data[i].name.indexOf(searchTextbox) != -1||res.data[i].setUserName.indexOf(searchTextbox) != -1  ) { //检索条件
            item.searchitems[count]=(res.data[i]);//将检索的数据添加到查询集
            count++;
           }
             item.saveitems=item.searchitems; //为每一个数据集都赋值
           }
         }})
      },
    
      createData() {
        this.$router.push({
           name: "PRecordIns",
          // params: { director:this.mumitems[0].director}
         });
        
      },
      editData(id) {
        this.$router.push({
          name: "PRecordEdit",
          params: { id: id}
        })
      },
      deleteData(id) {
        this.$axios.delete(uri+id)
        }
     
    },
    created() {
       var item=this;
       item.$axios.get(uri).then(function(res){
       item.mumitems = displayData(res.data)
       })
       
    },
  };
 
</script>

<style scoped>
  .fade-enter-active {
    transition: all 0.3s ease;
  }

  .fade-leave-active {
    transition: all 0.8s cubic-bezier(1, 0.5, 0.8, 1);
  }

  .fade-enter,
  .fade-leave-to {
    transform: translateX(10px);
    opacity: 0;
  }
</style>
