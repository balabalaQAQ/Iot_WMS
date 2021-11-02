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
          </b-card>
        </transition>
      </b-col>
    </b-row>
  </div>

</template>

<script>
  import data from './DemoData'
  export default {
    name: 'DataDetail',
    props: {
      caption: {
        type: String,
        default: '用户明细信息'
      },
    },
  }
</script>

<style scoped>
</style>
