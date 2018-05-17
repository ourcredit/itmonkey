<template>
  <div>
    <Card>
      <p slot="title">提现信息</p>
      <Row :gutter="8" slot="extra">
        <i-col span="6">
          <Input placeholder="昵称" v-model="params.name"/>
         
        </i-col>
        <i-col span="6">
          <Input placeholder="家族" v-model="params.num"/>
        
        </i-col>
        <i-col span="6">
          <Select style="width:140px" v-model="params.cate" placeholder="家族级别">
            <Option value="一级">一级</Option>
            <Option value="二级">二级</Option>
            <Option value="三级">三级</Option>
          </Select>
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
          title: "头像",
          key: "deviceName"
        },
        {
          title: "昵称",
          key: "deviceNum"
        },
        {
          title: "所属家族",
          key: "deviceType"
        },
        {
          title: "提现金额",
          key: "pointName"
        },
        {
          title: "税费",
          key: "pointName"
        },
        {
          title: "服务费",
          key: "pointName"
        },
        {
          title: "提现时间",
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