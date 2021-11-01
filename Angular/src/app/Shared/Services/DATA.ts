export const PlacetypeData = [
    {
        oid : 1,
        placeTypeName : 'Phường'
    },
    {
        oid : 2,
        placeTypeName : 'Trung tâm cai nghiện'
    },
    {
        oid : 3,
        placeTypeName : 'Trại Giam'
    }
];

export const GenderData = [
    {id: 0, Text: 'Nam'},
    {id: 1, Text: 'Nữ'}
];

export const ManageTypeData = [
    {oid: 1, Text: 'A'},
    {oid: 2, Text: 'B'},
    {oid: 3, Text: 'C'}
];

export const appMenuItem = [
    {
        oid : 1,
        label: 'Dashboard',
        icon: 'dashboard',
        link:  '/home/dashboard'
    },
    {
        oid: 2,
        label: 'Hồ sơ đối tượng',
        icon: 'group',      
        items: [
            {
                label: 'Danh sách đối tượng',
                link: '/home/addict/addict',
                icon: 'face'
            },
            {
                label: 'Tìm kiếm',
                link: '/home/addict/addict-search',
                icon: 'search'
            },
            {
                label: 'Lịch sử di chuyển',
                link: '/home/addict/addict-move',
                icon: 'history'
            },
            {
                label: 'Lịch sử hoạt động',
                icon: 'assignment_turned_in',         
                link: '/home/addict/addict-place'
            },
            {
                label: 'Lịch sử dùng ma túy',           
                icon: 'speaker_notes',
                link: '/home/addict/addict-drug'
            },
            {
                label: 'Phân loại đối tượng',
                icon: 'dvr',
                link: '/home/addict/addict-classify'
            }
        ]
    },
    {
        oid : 3,
        label: 'Danh mục',
        icon: 'table_chart',      
        items: [
            {
                label: 'Nơi quản lý',
                link: '/home/category/manageplace',
                icon: 'send'
              },
            {
                label: 'Loại ma túy',
                link: '/home/category/drugs',
                icon: 'send'
            },
            {
                label: 'Phân loại',
                link: '/home/category/classify',
                icon: 'send'
            },
            {
                label: 'Trình độ học vấn',
                link: '/home/category/edulevel',
                icon: 'send'
            }
      ]
    },
    {
        oid : 4,
        label: 'Báo cáo thống kê',
        icon: 'bar_chart',
        items: [
            {
                label: 'Theo hồ sơ cá nhân',
                link: '/item-2-1',
                icon: 'insert_chart_outlined'
            },
            {
                label: 'Theo phân loại',
                link: '/item-2-2',
                icon: 'insert_chart_outlined'
            },
            {
                label: 'Theo địa phương',
                link: '/item-2-2',
                icon: 'insert_chart_outlined'
            }
        ]
    },
    {
        oid : 5,
        label: 'Hệ thống',
        icon: 'computer',
        hidden: true,
        items: [
            {
            label: 'Người dùng',
            link: '/home/system/user-account',
            icon: 'account_circle'
            }
        ]
    }
  ];