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
                  <b-form-input id="searchText" type="text"></b-form-input>
                  <b-input-group-append>
                    <b-button variant="primary" size="sm"  @click="searchData()">查询</b-button>
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
                     :items="getmumitems "
                     :fields="fields"
                     :current-page="currentPage"
                     :per-page="perPage">
              <!-- 数据操作 -->
              <template slot="operation" slot-scope="data">
                <b-button variant="primary" size="sm" @click="editData(data.item.id)">审核</b-button>&nbsp;&nbsp;&nbsp;
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
              <!--
            <nav>
              <b-pagination size="sm"
                            :per-page="perPage"
                            v-model="currentPage"
                            prev-text="前一页"
                            next-text="下一页"
                            hide-goto-end-buttons
                            align="right"
                            @input="gotoPage(currentPage)" />
            </nav>
            -->
          </b-card>
        </transition>
      </b-col>
    </b-row>
  </div>
</template>
<script src="./site.js" asp-append-version="true"></script>

<script>
  // const uri = '/WeatherForecast';   // Web API 的访问服务地址
const uri ='https://localhost:5001/api/Order/';


  import { shuffleArray } from "@/shared/utils";
import { get } from 'http';
//import { shuffleArray } from "@/shared/utils";
 // import Oidc from "oidc-client" ;

  export default {
    name: "OrderIndex",
    props: {
      // 列表的表格标题
      caption: {
        type: String,
        default: "订单记录"
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

        mumitems: [],
    
        fields: [
       //   { key: "orderNumber", label: "序号" },
          { key: "orderNum", label: "订单号" },
          { key: "name", label: "订单名称" },
          { key: "description", label: "订单描述" },
          { key: "setTime", label: "申请时间" },
          { key: "status", label: "订单状态" },
          { key: "director", label: "负责人" },
          { key: "reviewer", label: "审核人" },
          { key: "price", label: "单价" },
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
       var statusitem=['待审核', '审核成功','审核失败', '已取消','已完成'];
        for( var i=0;i< res.data.length;i++){
           res.data[i].status=statusitem[res.data[i].status];
        }
       item.mumitems = res.data
       })
       return this.mumitems
      },
    },
    methods: {
    
      // 提取总行数
     getRowCount(mumitems) {
      return mumitems.length;
    },
   
      searchData(){

      },

      createData() {
        this.$router.push({
           name: "OrderIns",
          // params: { director:this.mumitems[0].director}
         });
        
      },
      editData(id) {
        this.$router.push({
          name: "OrderEdit",
          params: { id: id}
        })
      },
      deleteData(id) {
        this.$axios.delete(uri+id)
        }
     
    },
    created() {

       var item=this
       
       this.$axios.get(uri).then(function(res){
       
       item.mumitems = res.data})
       
    },
  };
            // 待办事宜的数据集合
 
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
