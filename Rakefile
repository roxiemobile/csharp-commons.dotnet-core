# coding: utf-8
base_dir = File.expand_path('..', __FILE__)

$:.unshift base_dir
require 'bundler'
Dir.glob(File.join(base_dir, 'Tasks', '**', '*.rb'), &method(:require))

PACKAGE ||= RoxieMobile::Package.new(
  name: 'CSharpCommons',
  base_dir: base_dir,
  projects_sources: [
    'Abstractions',
    'Data',
    'DataAnnotations',
    'Diagnostics',
    'Extensions',
    'Lang',
    'Localization.Xml',
    'Logging'
  ],
  projects_tests: [
    'Data.UnitTests',
    'Diagnostics.UnitTests'
  ]
)

desc 'Bump all versions to match PACKAGE_VERSION.'
task :update_version => 'all:update_version'
