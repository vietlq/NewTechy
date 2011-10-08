#!/usr/bin/python

class Joom2Py(object):
    def __init__(self, templatePath, destDir = None):
        self.templatePath = templatePath
    
    def set_template_path(self, templatePath):
        self.templatePath = templatePath
    
    def template_path(self):
        return self.templatePath
    
    def set_dest_dir(self, destDir):
        self.destDir = destDir
    
    def dest_dir(self):
        return self.destDir
    
    def process_template(self):
        pass
    
    def unzip_template(self):
        pass
    
    def verify_template(self):
        pass
    
    def move_static(self):
        pass
    
    def replace_lang(self):
        pass
    
    def replace_head(self):
        pass
    
    def replace_css_link(self):
        pass
    
    def replace_pathway(self):
        pass
    
    def replace_site_name(self):
        pass
    
    def replace_left_module(self):
        pass
    
    def replace_main_body(self):
        pass
    
    def clear_php_tags(self):
        pass
    
    def move_index_file(self):
        pass
    
    def append_css(self):
        pass
    
    def copy_license(self):
        pass
    
    def zip_template(self):
        pass

if __name__ == '__main__':
    pass
