/*
 Navicat Premium Data Transfer

 Source Server         : mysql
 Source Server Type    : MySQL
 Source Server Version : 80023
 Source Host           : localhost:3306
 Source Schema         : sea.core

 Target Server Type    : MySQL
 Target Server Version : 80023
 File Encoding         : 65001

 Date: 26/03/2021 17:38:28
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for sys_module
-- ----------------------------
DROP TABLE IF EXISTS `sys_module`;
CREATE TABLE `sys_module`  (
  `Id` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '主键',
  `CreateTime` timestamp(0) NOT NULL DEFAULT CURRENT_TIMESTAMP(0) COMMENT '创建时间',
  `CreateId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '创建用户',
  `ModifyTime` timestamp(0) NULL DEFAULT NULL COMMENT '更新时间',
  `ModifyId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '更新用户',
  `IsDelete` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否删除',
  `DeleteTime` timestamp(0) NULL DEFAULT NULL COMMENT '删除时间',
  `DeleteId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '删除用户',
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '名称',
  `LinkUrl` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '菜单链接地址',
  `Area` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '区域名称',
  `Controller` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '控制器名称',
  `Action` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'Action名称',
  `Icon` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '图标',
  `Code` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '菜单编号',
  `OrderSort` int(0) NOT NULL COMMENT '排序',
  `Description` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '描述',
  `IsMenu` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否是右侧菜单',
  `Enabled` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否激活',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '基础-接口表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_module
-- ----------------------------

-- ----------------------------
-- Table structure for sys_module2permission
-- ----------------------------
DROP TABLE IF EXISTS `sys_module2permission`;
CREATE TABLE `sys_module2permission`  (
  `Id` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '主键',
  `CreateTime` timestamp(0) NOT NULL DEFAULT CURRENT_TIMESTAMP(0) COMMENT '创建时间',
  `CreateId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '创建用户',
  `ModifyTime` timestamp(0) NULL DEFAULT NULL COMMENT '更新时间',
  `ModifyId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '更新用户',
  `IsDelete` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否删除',
  `DeleteTime` timestamp(0) NULL DEFAULT NULL COMMENT '删除时间',
  `DeleteId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '删除用户',
  `ModuleId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT 'api ID',
  `PermissionId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '菜单Id',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '基础-接口菜单关系表(暂时不用)' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_module2permission
-- ----------------------------

-- ----------------------------
-- Table structure for sys_permission
-- ----------------------------
DROP TABLE IF EXISTS `sys_permission`;
CREATE TABLE `sys_permission`  (
  `Id` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '主键',
  `CreateTime` timestamp(0) NOT NULL DEFAULT CURRENT_TIMESTAMP(0) COMMENT '创建时间',
  `CreateId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '创建用户',
  `ModifyTime` timestamp(0) NULL DEFAULT NULL COMMENT '更新时间',
  `ModifyId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '更新用户',
  `IsDelete` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否删除',
  `DeleteTime` timestamp(0) NULL DEFAULT NULL COMMENT '删除时间',
  `DeleteId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '删除用户',
  `Code` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '菜单执行的Action',
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '名称',
  `IsButton` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否按钮',
  `IsHide` bit(1) NULL DEFAULT NULL COMMENT '是否隐藏',
  `IskeepAlive` bit(1) NULL DEFAULT NULL COMMENT '是否保持',
  `Func` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '按钮事件',
  `OrderSort` int(0) NOT NULL COMMENT '排序',
  `Icon` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '菜单图标',
  `Description` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '菜单描述',
  `Enabled` bit(1) NOT NULL DEFAULT b'0' COMMENT '激活状态',
  `Pid` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '上一级菜单（0表示上一级无菜单）',
  `Mid` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '接口api',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '基础-路由菜单表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_permission
-- ----------------------------

-- ----------------------------
-- Table structure for sys_role
-- ----------------------------
DROP TABLE IF EXISTS `sys_role`;
CREATE TABLE `sys_role`  (
  `Id` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '主键',
  `CreateTime` timestamp(0) NOT NULL DEFAULT CURRENT_TIMESTAMP(0) COMMENT '创建时间',
  `CreateId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '创建用户',
  `ModifyTime` timestamp(0) NULL DEFAULT NULL COMMENT '更新时间',
  `ModifyId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '更新用户',
  `IsDelete` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否删除',
  `DeleteTime` datetime(0) NULL DEFAULT NULL COMMENT '删除时间',
  `DeleteId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '删除用户',
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '名称',
  `Description` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '描述',
  `OrderSort` int(0) NULL DEFAULT NULL COMMENT '排序',
  `Enabled` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否启动',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '基础-角色' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_role
-- ----------------------------

-- ----------------------------
-- Table structure for sys_role2module2permission
-- ----------------------------
DROP TABLE IF EXISTS `sys_role2module2permission`;
CREATE TABLE `sys_role2module2permission`  (
  `Id` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '主键',
  `CreateTime` timestamp(0) NOT NULL DEFAULT CURRENT_TIMESTAMP(0) COMMENT '创建时间',
  `CreateId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '创建用户',
  `ModifyTime` timestamp(0) NULL DEFAULT NULL COMMENT '更新时间',
  `ModifyId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '更新用户',
  `IsDelete` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否删除',
  `DeleteTime` timestamp(0) NULL DEFAULT NULL COMMENT '删除时间',
  `DeleteId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '删除用户',
  `RoleId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '角色id',
  `ModuleId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '菜单id',
  `PermissionId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'api ID',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '基础-角色接口菜单关系表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_role2module2permission
-- ----------------------------

-- ----------------------------
-- Table structure for sys_user
-- ----------------------------
DROP TABLE IF EXISTS `sys_user`;
CREATE TABLE `sys_user`  (
  `Id` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '主键',
  `CreateTime` timestamp(0) NOT NULL DEFAULT CURRENT_TIMESTAMP(0) COMMENT '创建时间',
  `CreateId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '创建用户',
  `ModifyTime` timestamp(0) NULL DEFAULT NULL COMMENT '更新时间',
  `ModifyId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '更新用户',
  `IsDelete` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否删除',
  `DeleteTime` datetime(0) NULL DEFAULT NULL COMMENT '删除时间',
  `DeleteId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '删除用户',
  `LoginName` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '登录名',
  `LoginPwd` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '登录密码',
  `RealName` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '真实名称',
  `Status` int(0) NULL DEFAULT NULL COMMENT '状态',
  `Remark` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注',
  `Name` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '名称',
  `Sex` int(0) NULL DEFAULT NULL COMMENT '性别',
  `Age` int(0) NULL DEFAULT NULL COMMENT '年纪',
  `Birth` timestamp(0) NULL DEFAULT NULL COMMENT '生日',
  `Addr` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '地址',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '基础-用户信息' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_user
-- ----------------------------
INSERT INTO `sys_user` VALUES ('dwqdwq', '2021-03-26 16:54:26', NULL, NULL, NULL, b'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sys_user` VALUES ('qwdew', '2021-03-26 16:53:46', NULL, NULL, NULL, b'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for sys_user2role
-- ----------------------------
DROP TABLE IF EXISTS `sys_user2role`;
CREATE TABLE `sys_user2role`  (
  `Id` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '主键',
  `CreateTime` timestamp(0) NOT NULL DEFAULT CURRENT_TIMESTAMP(0) COMMENT '创建时间',
  `CreateId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '创建用户',
  `ModifyTime` timestamp(0) NULL DEFAULT NULL COMMENT '更新时间',
  `ModifyId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '更新用户',
  `IsDelete` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否删除',
  `DeleteTime` datetime(0) NULL DEFAULT NULL COMMENT '删除时间',
  `DeleteId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '删除用户',
  `UserId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '用户Id',
  `RoleId` varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '角色Id',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '基础-用户和角色关系' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_user2role
-- ----------------------------

SET FOREIGN_KEY_CHECKS = 1;
