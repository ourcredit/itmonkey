import Cookies from 'js-cookie';
import Util from '@/libs/util'
import appconst from '@/libs/appconst'
const customer = {
    namespaced: true,
    state: {
        customers: [],
        totalCount: 0,
        pageSize: 10,
        currentPage: 1
    },
    mutations: {
        setPageSize(state, size) {
            state.pageSize = size;
        },
        setCurrentPage(state, page) {
            state.currentPage = page;
        }
    },
    "actions": {
        async getAll({
            state
        }, payload) {
            let page = {
                maxResultCount: state.pageSize,
                skipCount: (state.currentPage - 1) * state.pageSize,
                name: payload.data.name,
                family: payload.data.family,
                level: payload.data.level
            }
            let rep = await Util.ajax.get('/api/services/app/Customer/GetPagedCustomers', {
                params: page
            });
            state.customers = [];
            state.customers.push(...rep.data.result.items);
            state.totalCount = rep.data.result.totalCount;
        }
    }
};
export default customer;