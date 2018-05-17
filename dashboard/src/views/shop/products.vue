<template>
  <div>
    <Card>
      <p slot="title">商品维护</p>
      <Row :gutter="8" slot="extra">
        <i-col span="6">
          <Input placeholder="商品名" v-model="params.name" />
        </i-col>
        <i-col span="6">
          <Input placeholder="时间范围" v-model="params.num" />
        </i-col>
        <i-col span="6">
          <Select style="width:140px" v-model="params.cate" placeholder="商品状态">
            <Option value="格子机">格子机</Option>
            <Option value="无人销售机">无人销售机</Option>
            <Option value="咖啡机">咖啡机</Option>
            <Option value="饮料机">饮料机</Option>
          </Select>
        </i-col>
        <i-col span="3">
          <i-button @click="getpage" type="primary">查询</i-button>
        </i-col>
        <i-col span="3">
          <i-button @click="create" type="primary">添加</i-button>
        </i-col>
      </Row>
      <Table :columns="columns" border :data="products"></Table>
      <Page :total="totalCount" class="margin-top-10" @on-change="pageChange" @on-page-size-change="pagesizeChange" :page-size="pageSize"
        :current="currentPage"></Page>
    </Card>
    <Modal v-model="showEditModal" title="添加商品" @on-ok="save" okText="保存" cancelText="关闭">
      <div>


        <Form ref="roleForm" label-position="top" :rules="rule" :model="product">
          <Row>
            <Col :span="6">
            <Upload multiple type="drag" action="//jsonplaceholder.typicode.com/posts/">
              <div style="padding: 20px 0">
                <Icon type="ios-cloud-upload" size="52" style="color: #3399ff"></Icon>
                <p>上传图片</p>
              </div>
            </Upload>
            </Col>
            <Col :span="18">
            <FormItem label="商品名称" prop="productName">
              <Input v-model="product.productName" :maxlength="120" :minlength="1" />
            </FormItem>
            <Row>
              <Col :span="12">
              <FormItem label="商品数量" prop="productCount">
                <Input-number v-model="product.productCount" :min="1"></Input-number>
              </FormItem>
              </Col>
              <Col :span="12">
              <FormItem label="商品价格" prop="price">
                <Input-number v-model="product.price" :min="1"></Input-number>
              </FormItem>
              </Col>
            </Row>
            </Col>
          </Row>
          <FormItem label="结算类型" prop="settlementType">
            <Switch :model="product.monkeyCionDeal" size="large">
              <span slot="open">猿人币结算</span>
              <span slot="close">现金结算</span>
            </Switch>
          </FormItem>
          <FormItem label="商品描述" prop="productDescription">
            <Input type="textarea" :row="4" v-model="product.productDescription" :maxlength="500" />
          </FormItem>
        </Form>
      </div>
      <div slot="footer">
        <Button @click="showEditModal=false">关闭</Button>
        <Button @click="save" type="primary">保存</Button>
      </div>
    </Modal>
  </div>
</template>
<script>
  export default {
    methods: {
      create() {
        this.product = {};
        this.showEditModal = true;
      },
      async save() {
        this.$refs.roleForm.validate(async val => {
          if (val) {
            await this.$store.dispatch({
              type: "product/createOrUpdate",
              data: {
                product: this.product
              }
            });
            this.showEditModal = false;
            await this.getpage();
          }
        });
      },
      pageChange(page) {
        this.$store.commit("product/setCurrentPage", page);
        this.getpage();
      },
      pagesizeChange(pagesize) {
        this.$store.commit("product/setPageSize", pagesize);
        this.getpage();
      },
      async getpage() {
        await this.$store.dispatch({
          type: "product/getAll",
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
        product: {
          "productName": "",
          "productImage": "",
          "price": 0,
          "productDescription": "",
          "settlementType": 1,
          "productCount": 0
        },
        showEditModal: false,
        rule: {
          productName: [{
            required: true,
            message: "商品名",
            trigger: "blur"
          }]
        },
        columns: [{
            type: "selection",
            width: 60,
            align: "center"
          },
          {
            title: "商品名称",
            key: "productName"
          },
          {
            title: "单价",
            key: "price"
          },
          {
            title: "数量",
            key: "productCount"
          },
          {
            title: "创建时间",
            key: "creationTime"
          },
          {
            title: "操作",
            key: "action",
            width: 150,
            render: (h, params) => {
              return h("div", [
                h(
                  "Button", {
                    props: {
                      type: "primary",
                      size: "small"
                    },
                    style: {
                      marginRight: "5px"
                    },
                    on: {
                      click: () => {
                        this.product = this.products[params.index];
                        this.showEditModal = true;
                      }
                    }
                  },
                  "编辑"
                ),
                h(
                  "Button", {
                    props: {
                      type: "error",
                      size: "small"
                    },
                    on: {
                      click: async () => {
                        this.$Modal.confirm({
                          title: "",
                          content: "删除商品信息",
                          okText: "是",
                          cancelText: "否",
                          onOk: async () => {
                            await this.$store.dispatch({
                              type: "product/delete",
                              data: this.products[params.index]
                            });
                            await this.getpage();
                          }
                        });
                      }
                    }
                  },
                  "删除"
                )
              ]);
            }
          }
        ]
      };
    },
    computed: {
      products() {
        return this.$store.state.product.products;
      },
      totalCount() {
        return this.$store.state.product.totalCount;
      },
      currentPage() {
        return this.$store.state.product.currentPage;
      },
      pageSize() {
        return this.$store.state.product.pageSize;
      }
    },
    async created() {
      this.getpage();
    }
  };
</script>