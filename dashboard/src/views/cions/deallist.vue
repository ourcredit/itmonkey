<template>
  <div>
    <Card>
      <p slot="title">交易详情</p>
      <Row :gutter="8" slot="extra">
        <i-col span="6">
          <Input placeholder="卖出人" v-model="params.name">
          </Input>
        </i-col>
        <i-col span="6">
          <Input placeholder="买入人" v-model="params.num">
          </Input>
        </i-col>
        <i-col span="6">
          <Input placeholder="时间范围" v-model="params.num">
          </Input>
        </i-col>
        <i-col offset="1" span="3">
          <i-button @click="getpage" type="primary">查询</i-button>
        </i-col>
        <!-- <i-col span="3">
          <i-button @click="create" type="primary">添加</i-button>
        </i-col> -->
      </Row>
      <Table :columns="columns" border :data="devices"></Table>
      <Page :total="totalCount" class="margin-top-10" @on-change="pageChange" @on-page-size-change="pagesizeChange" :page-size="pageSize"
        :current="currentPage"></Page>
    </Card>
  </div>
</template>
<script>
export default {
  methods: {
    pageChange(page) {
      this.$store.commit("customer/setCurrentPage", page);
      this.getpage();
    },
    pagesizeChange(pagesize) {
      this.$store.commit("customer/setPageSize", pagesize);
      this.getpage();
    },
    async getpage() {
      await this.$store.dispatch({
        type: "customer/getAll",
        data: this.params
      });
    }
  },
  data() {
    return {
      params: {
        name: "",
        num: "",
        cate: ""
      },
      columns: [
        {
          type: "selection",
          width: 60,
          align: "center"
        },
        {
          title: "交易时间",
          key: "deviceName"
        },
        {
          title: "猿人币数量",
          key: "deviceNum"
        },
        {
          title: "单价",
          key: "controlNum"
        },
        {
          title: "总价",
          key: "deviceType"
        },
        {
          title: "卖出人",
          key: "pointName"
        },
        {
          title: "买入人",
          key: "pointName"
        }
      ]
    };
  },
  computed: {
    devices() {
      return this.$store.state.device.devices;
    },
    points() {
      return this.$store.state.device.points;
    },
    totalCount() {
      return this.$store.state.device.totalCount;
    },
    currentPage() {
      return this.$store.state.device.currentPage;
    },
    pageSize() {
      return this.$store.state.point.pageSize;
    }
  },
  async created() {
    this.getpage();
    await this.$store.dispatch({
      type: "device/getAllPoints"
    });
  }
};
</script>