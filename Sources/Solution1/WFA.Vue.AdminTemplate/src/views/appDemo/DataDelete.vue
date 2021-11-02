<template>
  <div class="animated fadeIn">
    <b-row>
      <b-col sm="12" md="12">
        <transition name="fade">
          <b-card>
            <div slot="header">
              <span style="font-size:20px"> {{caption}} </span>
            </div>
            <span>{{ $route.params.id }}</span>
            <button @click="Del($route.params.id)">确定</button>
          </b-card>
        </transition>
      </b-col>
    </b-row>
  </div>
</template>

<script>
import data from './DemoData'
  export default {
    name: 'DataDelete',
    props: {
      caption: {
        type: String,
        default: '删除用户信息'
      },
    },
    methods:{
      Del:function(id){
       
        console.log(id)
        for(var i=0;i<data.length;i++)
        {
          if(data[i].id===id)
          {
            data.splice(i,1)
            this.$router.go(-1)
          }
        }
      }
    }
  }
</script>

<style scoped>
</style>
