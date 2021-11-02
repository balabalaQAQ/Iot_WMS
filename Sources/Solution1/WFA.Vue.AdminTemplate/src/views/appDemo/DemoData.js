const UsersData = [
  { id: '91E52E80-E4EC-429E-BA46-27494195CB00', orderNumber: 0, name: 'John Doe', AdmissionTime: '2018/01/01', integral: 4124, lastTime: '2018/11/01',roleid:'56e137af-9fd1-4823-aca9-49b8e9d646b1' ,Statusid:'92009fbd-bbea-4c47-bbb4-21d93653bdf3'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB01', orderNumber: 1, name: 'Samppa Nori', AdmissionTime: '2018/01/01', integral: 600, lastTime: '2018/11/11' ,roleid:'733b31f5-1acb-4033-a63f-f33f00da28e0' ,Statusid:'92009fbd-bbea-4c47-bbb4-21d93653bdf3'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB02', orderNumber: 2, name: 'Estavan Lykos', AdmissionTime: '2018/02/01', integral: 0, lastTime: '2018/11/01',roleid:'733b31f5-1acb-4033-a63f-f33f00da28e0' ,Statusid:'cf2cb5ab-fb42-4bf2-8927-d463b8ef169b' },
  { id: '91E52E80-E4EC-429E-BA46-27494195CB03', orderNumber: 3, name: 'Chetan Mohamed', AdmissionTime: '2018/02/01', integral: 100, lastTime:'2018/11/01'  ,roleid:'733b31f5-1acb-4033-a63f-f33f00da28e0' ,Statusid:'92009fbd-bbea-4c47-bbb4-21d93653bdf3'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB04', orderNumber: 4, name: 'Derick Maximinus', AdmissionTime: '2018/03/01', integral: 235, lastTime: 'Pending' ,roleid:'6445b0a-9138-4111b-b0a6-8dc13f218f30' ,Statusid:'92009fbd-bbea-4c47-bbb4-21d93653bdf3'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB05', orderNumber: 5, name: 'Friderik Dávid', AdmissionTime: '2018/01/21', integral: 1232, lastTime: 'Active',roleid:'733b31f5-1acb-4033-a63f-f33f00da28e0' ,Statusid:'92009fbd-bbea-4c47-bbb4-21d93653bdf3' },
  { id: '91E52E80-E4EC-429E-BA46-27494195CB06', orderNumber: 6, name: 'Yiorgos Avraamu', AdmissionTime: '2018/01/01', integral: 520, lastTime: 'Active' ,roleid:'6445b0a-9138-4111b-b0a6-8dc13f218f30' ,Statusid:'2e09760e-d804-4aef-9365-2a612068b7a3'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB07', orderNumber: 7, name: 'Avram Tarasios', AdmissionTime: '2018/02/01', integral: 1314, lastTime: 'Banned',roleid:'6445b0a-9138-4111b-b0a6-8dc13f218f30' ,Statusid:'2e09760e-d804-4aef-9365-2a612068b7a3' },
  { id: '91E52E80-E4EC-429E-BA46-27494195CB08', orderNumber: 8, name: 'Quintin Ed', AdmissionTime: '2018/02/01', integral: 888, lastTime: 'Inaq     ctive' ,roleid:'56e137af-9fd1-4823-aca9-49b8e9d646b1' ,Statusid:'2e09760e-d804-4aef-9365-2a612068b7a3'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB09', orderNumber: 9, name: 'Enéas Kwadwo', AdmissionTime: '2018/03/01', integral: 520, lastTime: 'Pending',roleid:'733b31f5-1acb-4033-a63f-f33f00da28e0' ,Statusid:'2e09760e-d804-4aef-9365-2a612068b7a3'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB10', orderNumber: 10, name: 'Agapetus Tadeáš', AdmissionTime: '2018/01/21', integral: 1314, lastTime: 'Active' ,roleid:'6445b0a-9138-4111b-b0a6-8dc13f218f30' ,Statusid:'2e09760e-d804-4aef-9365-2a612068b7a3'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB11', orderNumber: 11, name: 'Carwyn Fachtna', AdmissionTime: '2018/01/01', integral: 520, lastTime: 'Active' ,roleid:'733b31f5-1acb-4033-a63f-f33f00da28e0' ,Statusid:'2e09760e-d804-4aef-9365-2a612068b7a3'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB12', orderNumber: 12, name: 'Nehemiah Tatius', AdmissionTime: '2018/02/01', integral: 1314, lastTime: 'Banned' ,roleid:'6445b0a-9138-4111b-b0a6-8dc13f218f30' ,Statusid:'2e09760e-d804-4aef-9365-2a612068b7a3'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB13', orderNumber: 13, name: 'Ebbe Gemariah', AdmissionTime: '2018/02/01', integral: 888, lastTime: 'Inactive' ,roleid:'733b31f5-1acb-4033-a63f-f33f00da28e0' ,Statusid:'2e09760e-d804-4aef-9365-2a612068b7a3'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB14', orderNumber: 14, name: 'Eustorgios Amulius', AdmissionTime: '2018/03/01', integral: 520, lastTime: 'Pending' ,roleid:'733b31f5-1acb-4033-a63f-f33f00da28e0' ,Statusid:'2e09760e-d804-4aef-9365-2a612068b7a3'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB15', orderNumber: 15, name: 'Leopold Gáspár', AdmissionTime: '2018/01/21', integral: 1314, lastTime: 'Active' ,roleid:'733b31f5-1acb-4033-a63f-f33f00da28e0' ,Statusid:'cf2cb5ab-fb42-4bf2-8927-d463b8ef169b'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB16', orderNumber: 16, name: 'Pompeius René', AdmissionTime: '2018/01/01', integral: 520, lastTime: 'Active' ,roleid:'56e137af-9fd1-4823-aca9-49b8e9d646b1' ,Statusid:'cf2cb5ab-fb42-4bf2-8927-d463b8ef169b'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB17', orderNumber: 17, name: 'Paĉjo Jadon', AdmissionTime: '2018/02/01', integral: 1314, lastTime: 'Banned',roleid:'733b31f5-1acb-4033-a63f-f33f00da28e0' ,Statusid:'92009fbd-bbea-4c47-bbb4-21d93653bdf3' },
  { id: '91E52E80-E4EC-429E-BA46-27494195CB18', orderNumber: 18, name: 'Micheal Mercurius', AdmissionTime: '2018/02/01', integral: 888, lastTime: 'Inactive' ,roleid:'56e137af-9fd1-4823-aca9-49b8e9d646b1' ,Statusid:'92009fbd-bbea-4c47-bbb4-21d93653bdf3'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB19', orderNumber: 19, name: 'Ganesha Dubhghall', AdmissionTime: '2018/03/01', integral: 520, lastTime: 'Pending' ,roleid:'56e137af-9fd1-4823-aca9-49b8e9d646b1' ,Statusid:'92009fbd-bbea-4c47-bbb4-21d93653bdf3'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB20', orderNumber: 20, name: 'Hiroto Šimun', AdmissionTime: '2018/01/21', integral: 1314, lastTime: 'Active' ,roleid:'733b31f5-1acb-4033-a63f-f33f00da28e0' ,Statusid:'cf2cb5ab-fb42-4bf2-8927-d463b8ef169b'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB21', orderNumber: 21, name: 'Vishnu Serghei', AdmissionTime: '2018/01/01', integral: 520, lastTime: 'Active' ,roleid:'6445b0a-9138-4111b-b0a6-8dc13f218f30' ,Statusid:'2e09760e-d804-4aef-9365-2a612068b7a3'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB22', orderNumber: 22, name: 'Zbyněk Phoibos', AdmissionTime: '2018/02/01', integral: 1314, lastTime: 'Banned' ,roleid:'6445b0a-9138-4111b-b0a6-8dc13f218f30' ,Statusid:'92009fbd-bbea-4c47-bbb4-21d93653bdf3'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB23', orderNumber: 23, name: 'Einar Randall', AdmissionTime: '2018/02/01', integral: 888, lastTime: 'Inactive' ,roleid:'6445b0a-9138-4111b-b0a6-8dc13f218f30' ,Statusid:'92009fbd-bbea-4c47-bbb4-21d93653bdf3'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB24', orderNumber: 24, name: 'Félix Troels', AdmissionTime: '2018/03/21', integral: 1314, lastTime: 'Active' ,roleid:'56e137af-9fd1-4823-aca9-49b8e9d646b1' ,Statusid:'92009fbd-bbea-4c47-bbb4-21d93653bdf3'},
  { id: '91E52E80-E4EC-429E-BA46-27494195CB25', orderNumber: 25, name: 'Aulus Agmundr', AdmissionTime: '2018/01/01', integral: 520, lastTime: 'Pending',roleid:'6445b0a-9138-4111b-b0a6-8dc13f218f30' ,Statusid:'92009fbd-bbea-4c47-bbb4-21d93653bdf3' },
  { id: '91E52E80-E4EC-429E-BA46-27494195CB42', orderNumber: 42, name: 'Ford Prefex', AdmissionTime: '2017/05/21', integral: 103, lastTime: 'Don\'t panic!' ,roleid:'56e137af-9fd1-4823-aca9-49b8e9d646b1' ,Statusid:'2e09760e-d804-4aef-9365-2a612068b7a3'}
]
const RoleData = [
  {roleid:'56e137af-9fd1-4823-aca9-49b8e9d646b1',role:'Ordinary',roleName:'普通会员'},
  {roleid:'733b31f5-1acb-4033-a63f-f33f00da28e0',role:'Senior',roleName:'高级会员'},
  {roleid:'6445b0a-9138-4111b-b0a6-8dc13f218f30',role:'Dika',roleName:'迪咔会员'},
]
const StatusData=[
  {Statusid:'92009fbd-bbea-4c47-bbb4-21d93653bdf3',StatusName:'正常'},
  {Statusid:'2e09760e-d804-4aef-9365-2a612068b7a3',StatusName:'冻结'},
  {Statusid:'cf2cb5ab-fb42-4bf2-8927-d463b8ef169b',StatusName:'废弃'}
]

const obj={RoleData,UsersData,StatusData}

export default obj
// export default RoleData
// export default StatusData