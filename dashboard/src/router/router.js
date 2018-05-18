import Main from '@/views/Main.vue';
import util from '@/libs/util.js';

//title properties are localization keys.

export const loginRouter = {
    path: '/login',
    name: 'login',
    meta: {
        title: '登陆页'
    },
    component: () =>
        import ('@/views/login.vue')
};

export const page404 = {
    path: '/*',
    name: 'error-404',
    meta: {
        title: '404-未找到页面'
    },
    component: () =>
        import ('@/views/error-page/404.vue')
};

export const page403 = {
    path: '/403',
    meta: {
        title: '403 - 未授权'
    },
    name: 'error-403',
    component: () =>
        import ('@//views/error-page/403.vue')
};

export const page500 = {
    path: '/500',
    meta: {
        title: '500 - 服务器内部错误'
    },
    name: 'error-500',
    component: () =>
        import ('@/views/error-page/500.vue')
};
export const locking = {
    path: '/locking',
    name: 'locking',
    component: () =>
        import ('@/views/main-components/lockscreen/components/locking-page.vue')
};

// A route which is not displayed in the left menu
export const otherRouter = {
    path: '/',
    name: 'otherRouter',
    component: Main,
    children: [{
        path: 'setting',
        title: '系列设置',
        name: 'settings',
      //  permission: 'Pages.Device.Manage.Create',
        component: () =>
            import ('@/views/cions/works.vue')
    }]
};

// Left menu items
export const appRouter = [{
    path: '/customers',
    icon: 'pinpoint',
    title: '用户管理',
    name: 'customers',
    component: Main,
    children: [{
        path: 'users',
        title: '用户信息',
        name: 'infos',
      //  permission: 'Pages.Point.Manage',
        component: () =>
            import ('@/views/customers/user.vue')
    }, {
        path: 'pickup',
        title: '提现信息',
        name: 'pickup',
       // permission: 'Pages.Point.View',
        component: () =>
            import ('@/views/customers/pickup.vue')
    }]
}, {
    path: '/monkeycion',
    icon: 'magnet',
    title: '猿人币信息',
    name: 'monkeycion',
    component: Main,
    children: [{
        path: 'works',
        title: '工作/任务信息',
        name: 'works',
       // permission: 'Pages.Device.Manage',
        component: () =>
            import ('@/views/cions/works.vue')
    },{
        path: 'deallist',
        title: '交易清单',
        name: 'deallist',
       // permission: 'Pages.Device.Manage',
        component: () =>
            import ('@/views/cions/deallist.vue')
    }]
}, {
    path: '/shops',
    icon: 'record',
    title: '商城管理',
    name: 'shops',
    component: Main,
    children: [{
        path: 'products',
        title: '商品管理',
        name: 'products',
      //  permission: 'Pages.Orders.OrderList',
        component: () =>
            import ('@/views/shop/products.vue')
    },{
        path: 'orders',
        title: '订单管理',
        name: 'orders',
       // permission: 'Pages.Orders.OrderList',
        component: () =>
            import ('@/views/shop/orders.vue')
    }]
}, {
    path: '/serial',
    icon: 'android-list',
    title: '系列管理',
    name: 'serial',
    component: Main,
    children: [{
        path: 'category',
        title: '轮播图管理',
        name: 'category',
      //  permission: 'Pages.AuditLogs.Logs',
        component: () =>
            import ('@/views/admin/roles/roles.vue')
    }]
}, {
    path: '/admin',
    icon: 'gear-a',
    title: '系统管理',
    name: 'administration',
    component: Main,
    children: [{
            path: 'users',
            title: '用户',
            name: 'users',
          //  permission: 'Pages.Administration.Users',
            component: () =>
                import ('@/views/admin/users/users.vue')
        },
        {
            path: 'roles',
            title: '角色',
            name: 'roles',
           // permission: 'Pages.Administration.Roles',
            component: () =>
                import ('@/views/admin/roles/roles.vue')
        }
    ]
}];
// All the routes defined above should be written in the routers below
export const routers = [
    loginRouter,
    otherRouter,
    locking,
    ...appRouter,
    page500,
    page403,
    page404
];