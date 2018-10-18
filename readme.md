This demo is built on:
Sitecore 8.1 rev 160302
Solr 6.3 http://archive.apache.org/dist/lucene/solr/6.3.0/

Solr support package: https://dev.sitecore.net/Downloads/Sitecore_Experience_Platform/Sitecore_81/Sitecore_Experience_Platform_81_Update2.aspx

Solr install instructions:
https://doc.sitecore.net/sitecore_experience_platform/82/setting_up_and_maintaining/search_and_indexing/walkthrough_setting_up_solr

Spatial search is implemented in Sitecore via:
http://www.ehabelgindy.com/sitecore-spatial-search-using-solr/

Note: you must build this from source - there is a bug with the binaries on the sitecore marketplace (see the PRs).

* Create solr cores for all of the sitecore indexes:

robocopy "%solr%\configsets\sitecore_standard_configs\conf" "%solr%\scan_site_index\conf" /mir
robocopy "%solr%\configsets\sitecore_standard_configs\conf" "%solr%\sitecore_analytics_index\conf" /mir
robocopy "%solr%\configsets\sitecore_standard_configs\conf" "%solr%\sitecore_core_index\conf" /mir
robocopy "%solr%\configsets\sitecore_standard_configs\conf" "%solr%\sitecore_fxm_master_index\conf" /mir
robocopy "%solr%\configsets\sitecore_standard_configs\conf" "%solr%\sitecore_fxm_web_index\conf" /mir
robocopy "%solr%\configsets\sitecore_standard_configs\conf" "%solr%\sitecore_list_index\conf" /mir
robocopy "%solr%\configsets\sitecore_standard_configs\conf" "%solr%\sitecore_marketingdefinitions_master\conf" /mir
robocopy "%solr%\configsets\sitecore_standard_configs\conf" "%solr%\sitecore_marketingdefinitions_web\conf" /mir
robocopy "%solr%\configsets\sitecore_standard_configs\conf" "%solr%\sitecore_marketing_asset_index_master\conf" /mir
robocopy "%solr%\configsets\sitecore_standard_configs\conf" "%solr%\sitecore_marketing_asset_index_web\conf" /mir
robocopy "%solr%\configsets\sitecore_standard_configs\conf" "%solr%\sitecore_master_index\conf" /mir
robocopy "%solr%\configsets\sitecore_standard_configs\conf" "%solr%\sitecore_suggested_test_index\conf" /mir
robocopy "%solr%\configsets\sitecore_standard_configs\conf" "%solr%\sitecore_testing_index\conf" /mir
robocopy "%solr%\configsets\sitecore_standard_configs\conf" "%solr%\sitecore_web_index\conf" /mir
robocopy "%solr%\configsets\sitecore_standard_configs\conf" "%solr%\social_messages_master\conf" /mir
robocopy "%solr%\configsets\sitecore_standard_configs\conf" "%solr%\social_messages_web\conf" /mir

Rename all of the Lucene config files to disabled, and enable all of the Solr config files.

VS project setup instructions: https://doc.sitecore.net/sitecore_experience_platform/developing/developing_with_sitecore/set_up_sitecore_and_visual_studio_for_development

SIM: http://dl.sitecore.net/updater/sim/